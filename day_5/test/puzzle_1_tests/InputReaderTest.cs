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
        public void produces_a_string_of_units_from_a_file()
        {
            var expected = "ZRbBrzlLEePzZMaqQAcCmyYpIiYZqAahHBXDdxbdDYnNyWAawcCwWUuj";
            var result = inputReader.ReadUnits("test-input.txt");
            Assert.AreEqual(expected, result);
        }
    }
}
