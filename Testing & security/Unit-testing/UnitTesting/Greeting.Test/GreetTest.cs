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
        public void GreetingsTest_Returns_Week_Day_GetMessage(DayOfWeek date)
        {
            //Arrange
            var day = new Mock<IDateGetter>();
            day.Setup(x => x.GetDate()).Returns(date);
            var greetings = new Greeter(day.Object);
            //Act
            var result = greetings.GetMessage();
            //Assert

            Assert.AreEqual("Work hard, weekend is on his way....", result);
        }
    }
}
