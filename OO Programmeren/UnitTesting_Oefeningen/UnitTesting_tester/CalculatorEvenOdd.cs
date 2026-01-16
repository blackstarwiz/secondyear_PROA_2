namespace UnitTesting_tester;

using UnitTesting;

[TestClass]
public class CalculatorEvenOdd
{
    private Calculator? calculator;

    [TestInitialize]
    public void Initialize()
    {
        calculator = new Calculator();
    }

    [TestMethod]
    public void CalculatorEven()
    {
        //Arrange
        bool expected = true;

        //Act
        if (calculator is not null)
            //Assert
            Assert.AreEqual(expected, calculator.Even(2));
    }

    [TestMethod]
    [DataRow(2)]
    [DataRow(5)]
    [DataRow(8)]
    [DataRow(4)]
    [DataRow(181)]
    [DataRow(56484)]
    public void CalculatorOdd(int a)
    {
        //Arrange
        //Act
        if (calculator is not null)
            //Assert
            Assert.IsTrue(calculator.Odd(a));
    }
}