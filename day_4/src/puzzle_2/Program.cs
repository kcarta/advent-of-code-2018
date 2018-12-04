using System;
using System.Linq;

namespace puzzle_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputReader = new InputReader();
            var input = inputReader.ReadIds("input.txt");
            var device = new Device();
            var sortedRecords = device.ParseToSortedRecords(input);
            var guardListings = device.LogMinutes(sortedRecords);
            var maxGuard = guardListings.OrderByDescending(guard => guard.SleepMinutes.Count).First();
            var maxMinute = maxGuard.SleepMinutes.GroupBy(count => count).OrderByDescending(group => group.Count()).Select(group => group.Key).First();
            var maxId = guardListings.Select(guard => new
            {
                GuardId = guard.Id,
                GuardMaxMinute = guard.SleepMinutes.GroupBy(count => count)
                                                   .OrderByDescending(group => group.Count())
                                                   .Select(group => new { Minute = group.Key, Count = group.Count() })
                                                   .FirstOrDefault()
            }).OrderByDescending(combo => combo?.GuardMaxMinute?.Count).First();
            Console.WriteLine($"{maxGuard.Id} slept most at minute {maxMinute}");
            Console.WriteLine($"Max id is: {maxId.GuardId} who slept most at minute {maxId.GuardMaxMinute.Minute}");
        }
    }
}
