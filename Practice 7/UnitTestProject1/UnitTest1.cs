using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practice_7;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool expected = true;
            int[] mas = { 0, 0, 0, 1, 0, 1, 1, 1 };
            bool actual = Program.CheckMono(mas);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            bool expected = false;
            int[] mas = { 0, 1, 1, 0, 0, 1, 1, 1 };
            bool actual = Program.CheckMono(mas);
            Assert.AreEqual(expected, actual);
        }

        
        [TestMethod]
        public void TestMethod3()
        {
            int[] expected = { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] actual = Program.MakeBinary(0);
            Assert.AreEqual(expected[0], actual[0]);
        }
    }
}
