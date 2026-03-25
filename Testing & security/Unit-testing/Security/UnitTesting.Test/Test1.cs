namespace UnitTesting.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void SumTest()
        {
            //Arrange
            //maaak variablen van klasse Calculator
            var cal = new Calculator();
            //zet waardes voor a en b
            var a = 1;
            var b = 4;
            //een variablen expected declareren om deze te vergelijken
            var expected = 5;
            //Action
            var result = cal.Sum(a,b);
            //Assert
            //Assert.AreEqual of zijn ze gelijk aan elkaar
            Assert.AreEqual(expected,result);
        }
    }
}
