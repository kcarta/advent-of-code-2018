using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class Device
{
    public IEnumerable<Record> ParseToSortedRecords(IEnumerable<string> list)
    {
        return list.Select(line =>
        {   // 00000000001111111111
            // 01234567890123456789
            // [1518-02-28 00:47] Guard...
            string timestamp = line.Substring(1, 16);
            DateTime time = DateTime.ParseExact(timestamp, "yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture);
            var text = line.Substring(19);
            return new Record(time, text);
        }).OrderBy(record => record.Timestamp);
    }

    public IEnumerable<Guard> LogMinutes(IEnumerable<Record> records)
    {
        var guards = new List<Guard>();
        Guard currentGuard = null;
        DateTime sleepStart = DateTime.MaxValue;
        DateTime sleepEnd = DateTime.MaxValue;
        foreach (var record in records)
        {
            EventType whatHappens = ParseEvent(record.Text);
            switch (whatHappens)
            {
                case EventType.CHANGE_OF_GUARD:
                    if (currentGuard != null) // If this is our first shift, we don't have a guard to add to the list
                    {
                        if (guards.Find(guard => guard.Id == currentGuard.Id) == null)
                        {
                            guards.Add(currentGuard);
                        }
                    }
                    currentGuard = ParseGuard(record.Text);
                    var matchingGuard = guards.Find(guard => guard.Id == currentGuard.Id); // If we've seen this guard before, let's use them instead
                    if (matchingGuard != null)
                    {
                        currentGuard = matchingGuard;
                    }
                    break;
                case EventType.GUARD_FALLS_ASLEEP:
                    sleepStart = record.Timestamp;
                    break;
                case EventType.GUARD_WAKES_UP:
                    sleepEnd = record.Timestamp;
                    if (currentGuard == null || sleepStart == DateTime.MaxValue)
                    {
                        throw new Exception("Something is clearly wrong in my logic");
                    }
                    currentGuard.SleepMinutes.AddRange(CalculateMinutesSlept(sleepStart, sleepEnd));
                    break;
                default:
                    break;
            }
        }
        return guards;
    }

    private IEnumerable<int> CalculateMinutesSlept(DateTime sleepStart, DateTime sleepEnd)
    {
        List<int> minutes = new List<int>();
        while (sleepStart < sleepEnd) // This replaces a very fancy LINQ statement that I didn't trust (because I didn't test it)
        {
            minutes.Add(sleepStart.Minute);
            sleepStart = sleepStart.AddMinutes(1);
        }
        return minutes;
    }

    private Guard ParseGuard(string text)
    {
        // 01234567890
        // Guard #1901 begins shift
        string id = string.Concat(text.Skip(7).TakeWhile(character => Char.IsDigit(character)));
        return new Guard(id);
    }

    private EventType ParseEvent(string recordText)
    {
        switch (recordText.First())
        {
            case 'G':
                return EventType.CHANGE_OF_GUARD;
            case 'f':
                return EventType.GUARD_FALLS_ASLEEP;
            case 'w':
                return EventType.GUARD_WAKES_UP;
            default:
                throw new FormatException("Record begins with an unknown character");
        }
    }

    private enum EventType
    {
        CHANGE_OF_GUARD,
        GUARD_FALLS_ASLEEP,
        GUARD_WAKES_UP
    }
}