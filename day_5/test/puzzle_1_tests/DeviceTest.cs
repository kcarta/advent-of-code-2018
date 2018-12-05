using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace puzzle_1_tests
{
    [TestClass]
    public class DeviceTest
    {
        Device device;
        public DeviceTest()
        {
            device = new Device();
        }

        [TestMethod]
        public void parse_correctly_converts_string_to_units()
        {
            string input = "aBcC";
            List<Unit> result = device.Parse(input);
            Assert.AreEqual(result.ElementAt(0), new Unit('a'));
            Assert.AreEqual(result.ElementAt(1), new Unit('B'));
            Assert.AreEqual(result.ElementAt(2), new Unit('c'));
            Assert.AreEqual(result.ElementAt(3), new Unit('C'));
        }

        [TestMethod]
        public void process_reduces_collection_of_units()
        {
            var input = "dabAcCaCBAcCcaDA".Select(character => new Unit(character)).ToList();
            List<Unit> result = device.Process(input);
            result.Select(unit => unit.Type).ToList().ForEach(Console.Write);
            Assert.AreEqual(10, result.Count);
        }

        [TestMethod]
        public void parse_returns_sorted_results()
        {
        }
    }
}
