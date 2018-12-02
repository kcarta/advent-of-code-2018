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
        public void produces_list_of_ids_from_a_file()
        {
            var expected = new[] { "abc", "def" };
            var result = inputReader.ReadIds("test-input.txt");
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
