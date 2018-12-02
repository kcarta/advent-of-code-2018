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
        public void takes_a_list_of_ids_and_returns_a_list_of_scan_results()
        {
            var ids = new List<string>() {
                "abcdef",
                "ababab",
            };

            var results = device.Scan(ids);

            Assert.AreEqual(2, results.Count());
        }

        [TestMethod]
        public void detects_if_any_letter_in_any_id_is_repeated_two_times()
        {
            var ids = new List<string>() {
                "abbcde",
                "abcdef"
            };

            var results = device.Scan(ids);

            Assert.IsTrue(results.First().HasDuplicate);
            Assert.IsFalse(results.ElementAt(1).HasDuplicate);
        }

        [TestMethod]
        public void detects_if_any_letter_in_any_id_is_repeated_three_times()
        {
            var ids = new List<string>() {
                "abcccd",
                "abcdef"
            };

            var results = device.Scan(ids);

            Assert.IsTrue(results.First().HasTriplicate);
            Assert.IsFalse(results.ElementAt(1).HasTriplicate);
        }

        [TestMethod]
        public void detects_different_kinds_of_repeats_in_same_id()
        {
            var ids = new List<string>() {
                "bababc",
                "abcdef"
            };

            var results = device.Scan(ids);

            Assert.IsTrue(results.First().HasDuplicate);
            Assert.IsTrue(results.First().HasTriplicate);
            Assert.IsFalse(results.ElementAt(1).HasDuplicate);
            Assert.IsFalse(results.ElementAt(1).HasTriplicate);
        }

        [TestMethod]
        public void determines_checksum_from_list_of_scan_results()
        {
            var scanResults = new List<ScanResult>()
            {
                new ScanResult(true, false),
                new ScanResult(false, true),
                new ScanResult(true, true)
            };

            var checksum = device.CalculateChecksum(scanResults);
            Assert.AreEqual(4, checksum);
        }
    }
}
