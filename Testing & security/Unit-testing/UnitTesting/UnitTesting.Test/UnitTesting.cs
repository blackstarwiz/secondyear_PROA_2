namespace UnitTesting.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void SumTest()
        {
            //Arrange
            var calculator = new Calculator();
            var a = 2;
            var b = 3;
            var expected = 5;
            //Act
            var result = calculator.Sum(a, b);
            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}