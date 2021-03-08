using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalcLibrary;
using NUnit.Framework;

namespace CalcLibraryTest
{
    [TestFixture]
    public class CalculatorTest
    {
        SimpleCalculator sc = new SimpleCalculator();
        [TestCase(7,5,2)]
        [TestCase(10,2,8)]
        [TestCase(20,10,10)]
        public void SubtractionTest(double a, double b, double expextedResult)
        {
            double result = sc.Subtraction(a, b);
            Assert.AreEqual(expextedResult, result);
        }

        [TestCase(5, 2, 10)]
        [TestCase(2,2,4)]
        [TestCase(10,10,100)]
        public void MultiplicationTest(double a, double b, double expectedResult)
        {
            double result = sc.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(6, 2, 3)]
        [TestCase(10,2,5)]
        [TestCase(20,0,4)]
        public void DivisionTest(double a, double b, double expectedResult)
        {
            try
            {
                double result = sc.Division(a, b);
                Assert.That(result, Is.EqualTo(expectedResult));
            }
            catch(Exception)
            {
                Assert.Fail("Division by zero");
            }
            
        }
        [Test]
        public void TestAddAndClear()
        {
            double result = sc.Addition(5, 2);
            Assert.AreEqual(7, result);
            sc.AllClear();
            double result1 = sc.GetResult;
            Assert.AreEqual(result1, 0);
        }
    }
}
