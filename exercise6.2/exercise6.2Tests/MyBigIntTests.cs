using exercise6._2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1.Tests
{
    [TestClass]
    public class MyBigIntTests
    {
        [TestMethod]
        public void AdditionTest()
        {
            MyBigInt a = new MyBigInt("123");
            MyBigInt b = new MyBigInt("456");

            MyBigInt result = a + b;

            Assert.AreEqual("579", result.MyNumber);
        }

        [TestMethod]
        public void SubtractionTest()
        {
            MyBigInt a = new MyBigInt("456");
            MyBigInt b = new MyBigInt("123");

            MyBigInt result = a - b;

            Assert.AreEqual("333", result.MyNumber);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            MyBigInt a = new MyBigInt("123");
            MyBigInt b = new MyBigInt("456");

            MyBigInt result = a * b;

            Assert.AreEqual("56088", result.MyNumber);
        }
        [TestMethod]
        public void NegativeNumberTest()
        {
            MyBigInt a = new MyBigInt("-123");
            MyBigInt b = new MyBigInt("456");

            MyBigInt result = a + b;

            Assert.AreEqual("333", result.MyNumber);
        }

        [TestMethod]
        public void LargeNumberTest()
        {
            MyBigInt a = new MyBigInt("999999999999999999999999999999");
            MyBigInt b = new MyBigInt("1");

            MyBigInt result = a + b;

            Assert.AreEqual("1000000000000000000000000000000", result.MyNumber);
        }

        [TestMethod]
        public void ZeroMultiplicationTest()
        {
            MyBigInt a = new MyBigInt("123");
            MyBigInt b = new MyBigInt("0");

            MyBigInt result = a * b;

            Assert.AreEqual("0", result.MyNumber);
        }
        [TestMethod]
        public void NegativeSubtractionTest()
        {
            MyBigInt a = new MyBigInt("-456");
            MyBigInt b = new MyBigInt("-123");

            MyBigInt result = a - b;

            Assert.AreEqual("-333", result.MyNumber);
        }
        [TestMethod]
        public void NegativeMultiplicationTest()
        {
            MyBigInt a = new MyBigInt("123");
            MyBigInt b = new MyBigInt("-456");

            MyBigInt result = a * b;

            Assert.AreEqual("-56088", result.MyNumber);
        }
        [TestMethod]
        public void NegativeNumberSubtractionTest()
        {
            MyBigInt a = new MyBigInt("-789");
            MyBigInt b = new MyBigInt("123");

            MyBigInt result = a - b;

            Assert.AreEqual("-912", result.MyNumber);
        }
        [TestMethod]
        public void ComplexSubtractionTest()
        {
            MyBigInt a = new MyBigInt("1000000000000000000000000000000");
            MyBigInt b = new MyBigInt("999999999999999999999999999999");

            MyBigInt result = a - b;

            Assert.AreEqual("1", result.MyNumber);
        }
    }
}

