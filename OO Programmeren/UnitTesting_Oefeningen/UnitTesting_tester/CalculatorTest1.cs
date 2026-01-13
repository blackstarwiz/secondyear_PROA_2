using UnitTesting;

namespace UnitTesting_tester
{
    [TestClass]
    public sealed class CalculatorTest1
    {
        [TestMethod]
        public void SumTest()
        {
            //ARRANGE
            Calculator calculator = new Calculator();  // Maak een nieuwe calculator instantie
            int a = 2;                          // Waarde voor parameter a
            int b = 3;                          // Waarde voor parameter b
            int expected = 5;                   // Verwacht resultaat
            //ACT
            int result = calculator.Sum(a, b);  // Sum methode aanroepen
            //ASSERT
            Assert.AreEqual(expected, result);  // Testen of resultaat gelijk is aan verwachte waarde 
        }

    }
}
