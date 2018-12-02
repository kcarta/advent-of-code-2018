using System;

namespace puzzle_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputReader = new InputReader();
            var input = inputReader.ReadIds("input.txt");
            var device = new Device();
            var results = device.Scan(input);
            var match = device.FindCommonLettersAtMatch(results);
            Console.WriteLine($"Match is: {match}");
        }
    }
}
