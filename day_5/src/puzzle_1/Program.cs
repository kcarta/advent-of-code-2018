using System;
using System.Linq;

namespace puzzle_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputReader = new InputReader();
            var input = inputReader.ReadUnits("input.txt");
            var device = new Device();
            var units = device.Parse(input);
            var result = device.Process(units);
            result.Select(unit => unit.Type).ToList().ForEach(Console.Write);
            Console.WriteLine($"Device has {result.Count} units");
        }
    }
}
