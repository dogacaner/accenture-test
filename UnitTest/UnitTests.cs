using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DogaCanerTest;

namespace UnitTest
{
    [TestClass]
    public class UnitTests
    {
        private string removeTestString = "aaba kouq bux";
        private string changeTestString = "abbcccaaeeeeb bfffffca ccab";

        [TestMethod]
        public void RemoveRepeatedCharactersTest1()
        {
            var result = Program.RemoveRepeatedCharacters(removeTestString, 2);
            Assert.AreEqual(result, "koq x");
        }

        [TestMethod]
        public void RemoveRepeatedCharactersTest2()
        {
            var result = Program.RemoveRepeatedCharacters(removeTestString, 3);
            Assert.AreEqual(result, "b kouq bux");
        }

        [TestMethod]
        public void RemoveRepeatedCharactersTest3()
        {
            var result = Program.RemoveRepeatedCharacters(removeTestString, 4);
            Assert.AreEqual(result, "aaba kouq bux");
        }

        [TestMethod]
        public void ChangeRepeatedCharactersTest1()
        {
            var result = Program.ChangeRepeatedCharacters(changeTestString, 9);
            Assert.AreEqual(result, "abbcccaaeeeeb bfffffca ccab");
        }

        [TestMethod]
        public void ChangeRepeatedCharactersTest2()
        {
            var result = Program.ChangeRepeatedCharacters(changeTestString, 5);
            Assert.AreEqual(result, "abbcccaaeeeeb b*****ca ccab");
        }

        [TestMethod]
        public void ChangeRepeatedCharactersTest3()
        {
            var result = Program.ChangeRepeatedCharacters(changeTestString, 4);
            Assert.AreEqual(result, "abbcccaa****b b*****ca ccab");
        }
        [TestMethod]
        public void ChangeRepeatedCharactersTest4()
        {
            var result = Program.ChangeRepeatedCharacters(changeTestString, 3);
            Assert.AreEqual(result, "abb***aa****b b*****ca ccab");
        }
        [TestMethod]
        public void ChangeRepeatedCharactersTest5()
        {
            var result = Program.ChangeRepeatedCharacters(changeTestString, 2);
            Assert.AreEqual(result, "a***********b b*****ca **ab");
        }
    }
}
