using UnitTesting;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace UnitTesting_tester;

[TestClass]
public class CalculatorTest2
{
    Calculator? calculator;
    [TestInitialize]
    public void ArrangeTests()
    {
        calculator = new Calculator();
    }

    [DataTestMethod]
    [DataRow(6)]
    [DataRow(23)]
    [DataRow(4)]
    [DataRow(1244)]
    [DataRow(53)]
    [DataRow(18)]
    [DataRow(244)]
    [DataRow(44)]
    [DataRow(12)]
    [DataRow(1)]
    public void EvenTestTrue(int number)
    {
        if (calculator is null)
            throw new NullReferenceException("Initialize is niet gebeurt");

        bool result = calculator.Even(number);

        Assert.IsTrue(result);
    }

    [DataTestMethod]
    [DataRow(6)]
    [DataRow(23)]
    [DataRow(4)]
    [DataRow(1244)]
    [DataRow(53)]
    [DataRow(18)]
    [DataRow(244)]
    [DataRow(44)]
    [DataRow(12)]
    [DataRow(1)]
    public void EvenTestFalse(int number)
    {
        if (calculator is null)
            throw new NullReferenceException("Initialize is niet gebeurt");

        bool result = calculator.Even(number);

        Assert.IsFalse(result);
    }
}
