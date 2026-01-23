namespace UnitTesting_tester;

using UnitTesting;

[TestClass]
public class CalculatorTester
{
    private Calculator calculator;

    [TestInitialize]
    public void Initialize()
    {
        calculator = new Calculator();
    }

    [TestMethod]
    public void TestDivide()
    {
        //Act
        double expectedResult = 20 / 4;
        double result = calculator.Divide(20, 4);
        //Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void TestDivideByZero()
    {
        //Act
        double result = calculator.Divide(20, 0);
        //Assert
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void TestDivideByZeroException()
    {
        //Act
        double result = calculator.Divide(20, 0);
        //Assert
        //Versie 1: hier wordt geen assert gebruikt als je execptions wilt testen
    }

    [TestMethod]
    [ExpectedException(typeof(DivideByZeroException))]
    public void TestDivideByZeroExceptionTryCatch()
    {
        try
        {
            //Act
            double result = calculator.Divide(20, 4);
        }
        catch (DivideByZeroException)
        {
            //Assert
            //Versie 2: hier wordt er ook geen assert gedaan maar in plaats daarvan is het een try catch
        }
    }

    [TestMethod]
    
    public void TestDivideByZeroAssertException()
    {
        //Act
        //Assert
        Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(20, 0));
    }
}