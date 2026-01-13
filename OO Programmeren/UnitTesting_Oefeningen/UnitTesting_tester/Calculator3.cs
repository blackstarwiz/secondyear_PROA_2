using UnitTesting;
namespace UnitTesting_tester;

[TestClass]
public class Calculator3
{
    //ARRANGE
    Calculator? calculator;
    [TestInitialize]
    public void Intialize()
    {
        calculator = new Calculator();
    }


    [DataTestMethod]
    [DataRow(68.2,1.60)]
    [DataRow(85.5,1.75)]
    [DataRow(120.4,1.72)]
    public void TestBMICorrect(double gewicht,double lengte)
    {
        //ARRANGE
        double lengtePow2 = Math.Pow(lengte, 2);

        double expected = Math.Round(gewicht / lengtePow2);
        
        if (calculator is not null)
        {
            //ACT
            double result = calculator.BMI(gewicht, lengte);
            //ASSERT

            Assert.AreEqual(expected, result);
        }
        else
        {
            throw new NullReferenceException("Calculator-object is null");
        }
    }
}
