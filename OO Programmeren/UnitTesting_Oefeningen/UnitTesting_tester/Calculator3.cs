using UnitTesting;

namespace UnitTesting_tester;

[TestClass]
public class Calculator3
{
    //ARRANGE
    private Calculator? calculator;

    [TestInitialize]
    public void Intialize()
    {
        calculator = new Calculator();
    }

    [DataTestMethod]
    [DataRow(68.2, 1.60)]
    [DataRow(85.5, 1.75)]
    [DataRow(120.4, 1.72)]
    public void TestBMICorrect(double gewicht, double lengte)
    {
        //ARRANGE
        double lengtePow2 = Math.Pow(lengte, 2);

        double expected = Math.Round(gewicht / lengtePow2);

        if (calculator is null)
            throw new NullReferenceException("Calculator-object is null");
        //ACT
        //ASSERT
        Assert.AreEqual(expected, calculator.BMICalculator(gewicht,lengte));
    }
}