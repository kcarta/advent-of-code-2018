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
        public void parse_correctly_interprets_timestamps()
        {
            var input = new[] {
                "[1518-02-28 00:47] falls asleep",
            };

            var response = device.ParseToSortedRecords(input);

            Assert.AreEqual(new DateTime(1518, 02, 28, 00, 47, 0), response.First().Timestamp);

        }

        [TestMethod]
        public void parse_correctly_interprets_text()
        {
            var input = new[] {
                "[1518-02-28 00:47] falls asleep",
            };

            var response = device.ParseToSortedRecords(input);

            Assert.AreEqual("falls asleep", response.First().Text);
        }

        [TestMethod]
        public void parse_returns_sorted_results()
        {
            var input = new[] {
                "[1518-02-28 00:47] 2",
                "[1518-04-28 00:47] 3",
                "[1518-02-28 00:43] 1",
            };

            var response = device.ParseToSortedRecords(input);

            Assert.AreEqual("1", response.First().Text);
            Assert.AreEqual("2", response.ElementAt(1).Text);
            Assert.AreEqual("3", response.ElementAt(2).Text);
        }
    }
}
