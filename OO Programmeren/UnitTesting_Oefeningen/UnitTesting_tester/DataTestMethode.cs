using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting;


namespace UnitTesting_tester
{
    [TestClass]
    public class DataTestMethode
    {
        Calculator calculator;
        [TestInitialize]
        public void Initialize()
        {
            calculator = new Calculator();
        }


        [TestMethod]
        [DataRow(1.62,85)]
        [DataRow(1.72,120)]
        [DataRow(1.52,35)]
        [DataRow(1.85,95)]
        public void BMICalculatorIsCorrect(double lengte, double gewicht)
        {
            //Arrange
            var expected = Math.Round(gewicht / (Math.Pow(lengte, 2)));
            //Act
            //Assert
            Assert.AreEqual(expected, calculator.BMICalculator(gewicht, lengte));
            
        }


        [TestMethod]
        [DataRow(12)]
        [DataRow(16)]
        [DataRow(20)]
        [DataRow(23)]
        [DataRow(28)]
        [DataRow(32)]
        [DataRow(35)]
        public void BMIRangeCorrectEnum(double bmi)
        {
            //Arrange
            string expected;
            if (bmi <= 16) expected = "UnderWeight";
            else if (bmi <= 23) expected = "HealthyWeight";
            else if (bmi < 32) expected = "OverWeight";
            else expected = "OverWeight";

            //Act
            //Assert
            
            Assert.AreEqual(expected, calculator.BMIRange(bmi).ToString());
        }

        [TestMethod]
        public void BMICalculatorArgumentOutOfRangeException_GewichtOnder30()
        {
            //Arrange
            //Act
            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calculator.BMICalculator(23, 1.75));
        }
    }
}
