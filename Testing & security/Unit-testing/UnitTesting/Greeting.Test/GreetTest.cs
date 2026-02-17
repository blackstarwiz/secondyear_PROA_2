using Moq;

namespace Greetings.Test
{
    [TestClass]
    public sealed class GreetTest

    {
        [TestMethod]
        [DataRow(DayOfWeek.Saturday)]
        [DataRow(DayOfWeek.Sunday)]
        public void GreetingsTest_Returns_Weekend_GetMessage(DayOfWeek date)
        {
            //Arrange
            var day = new Mock<IDateGetter>();
            day.Setup(x => x.GetDate()).Returns(date);
            var greetings = new Greeter(day.Object);
            //Act
            var result = greetings.GetMessage();
            //Assert

            Assert.AreEqual("Party time.....It's weekend", result);
        }

        [TestMethod]
        [DataRow(DayOfWeek.Monday)]
        [DataRow(DayOfWeek.Tuesday)]
        [DataRow(DayOfWeek.Wednesday)]
        [DataRow(DayOfWeek.Thursday)]
        [DataRow(DayOfWeek.Friday)]
        public void GreetingsTest_Returns_Week_Day_GetMessage(DayOfWeek mockDate)
        {
            //Arrange
            var day = new Mock<IDateGetter>();
            day.Setup(x => x.GetDate()).Returns(mockDate);//x is IDateGetter object(Interface) die getdate gebruikt en dayoftheweek.(day) terug geeft
            var greetings = new Greeter(day.Object);//we maken nieuw object Greeter die dayoftheweek meekrijgt (mockdate)
            //Act
            //
            var result = greetings.GetMessage();//Ga naar GetMessage voor info -->class Greeter
            //Assert

            Assert.AreEqual("Work hard, weekend is on his way....", result);
        }
    }
}
