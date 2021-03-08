using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CalcLibrary;

namespace CalcLibraryTest
{
    [TestFixture]
    public class CalculatorTest
    {
        SimpleCalculator calc = new SimpleCalculator();
        [Test]
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Start Testing");
        }
        
        [TestCase(5,2,3)]
        
        public void SubtractionTest(double a,double b,double expectedResult)
        {
            double result = calc.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

       
        [TestCase(5,2,10)]
        public void MultiplicationTest(double a ,double b, double expectedResult)
        {
            double result = calc.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
       
        [TestCase(6,2,3)]
        public void DivisionTest(double a, double b, double expectedResult)
        {
            double result = calc.Division(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [TestCase(5,2,7)]
        public void AdditionTest(double a, double b, double expectedResult)
        {
            double result = calc.Addition(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
        [Test]
        [TearDown]
        public void GetResultTest()
        {
            calc.AllClear();
            double result = calc.GetResult;
            Assert.AreEqual(result, 0);
        }
       

    }
}
