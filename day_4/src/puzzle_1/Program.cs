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
            // My design broke down around here - about the time I stopped writing tests
            // the final D in TDD should actually be "Design"
            var maxGuard = guardListings.OrderByDescending(guard => guard.SleepMinutes.Count).First();
            var maxMinute = maxGuard.SleepMinutes.GroupBy(count => count).OrderByDescending(group => group.Count()).Select(group => group.Key).First();
            guardListings.OrderByDescending(guard => guard.SleepMinutes.Count).ToList().ForEach((guard) => Console.WriteLine($"{guard}: {guard.SleepMinutes.Count}"));
            maxGuard.SleepMinutes.GroupBy(count => count).OrderByDescending(group => group.Count()).ToList().ForEach(group => Console.WriteLine($"Group: {group.Key} has {group.Count()} elements")); //.Select(group => group.Key).ToList().ForEach(Console.WriteLine);
            Console.WriteLine($"{maxGuard.Id} slept most at minute {maxMinute}");
        }
    }
}
