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
                "abcde",
                "axcye",
                "fghij",
                "fguij",
            };

            var results = device.Scan(ids);

            Assert.AreEqual(4, results.Count());
        }

        [TestMethod]
        public void determines_number_of_differences_for_results()
        {
            var ids = new List<string>() {
                "abcde",
                "axcye",
                "fghij",
                "fguij",
                "zzzzz",
            };
            var expected = new List<ScanResult>() {
                new ScanResult("abcde", 2, "ace"),
                new ScanResult("axcye", 2, "ace"),
                new ScanResult("fghij", 1, "fgij"),
                new ScanResult("fguij", 1, "fgij"),
                new ScanResult("zzzzz", 5, "" ),
            };

            var results = device.Scan(ids);

            CollectionAssert.AreEqual(expected.ToArray(), results.ToArray());
        }

        [TestMethod]
        public void determines_common_letters_for_results()
        {
            var matches = new List<ScanResult>() {
                new ScanResult("abcde", 2, "ace"),
                new ScanResult("axcye", 2, "ace"),
                new ScanResult("fghij", 1, "fgij"),
                new ScanResult("fguij", 1, "fgij"),
                new ScanResult("zzzzz", 5, "" ),
            };
            string result = device.FindCommonLettersAtMatch(matches);
            Assert.AreEqual("fgij", result);
        }
    }
}
