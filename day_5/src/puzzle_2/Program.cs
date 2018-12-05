using System;
using System.Collections.Generic;
using System.Linq;

namespace puzzle_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputReader = new InputReader();
            var input = inputReader.ReadUnits("input.txt");
            var device = new Device();
            Dictionary<char, int> charCounts = new Dictionary<char, int>();
            for (char character = 'a'; character <= 'z'; character++)
            {
                var newInput = new string(input.Where(c => char.ToLower(c) != char.ToLower(character)).ToArray());
                var count = device.Process(device.Parse(newInput)).Count;
                charCounts.Add(character, count);
            }
            foreach (var pair in charCounts)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            var lowestCount = charCounts.Where(group => group.Value != 10638).OrderBy(group => group.Value).First().Value;
            Console.WriteLine($"Lowest count is {lowestCount}");
        }
    }
}
