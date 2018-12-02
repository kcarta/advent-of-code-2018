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
    }
}
