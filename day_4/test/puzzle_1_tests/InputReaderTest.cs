using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace puzzle_1_tests
{
    [TestClass]
    public class InputReaderTest
    {
        InputReader inputReader;
        public InputReaderTest()
        {
            inputReader = new InputReader();
        }

        [TestMethod]
        public void produces_list_of_records_from_a_file()
        {
            var expected = new[]{
                "[1518-02-28 00:47] falls asleep",
                "[1518-10-23 23:47] Guard #1627 begins shift",
                "[1518-10-25 00:41] wakes up",
            };
            var result = inputReader.ReadIds("test-input.txt");
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
