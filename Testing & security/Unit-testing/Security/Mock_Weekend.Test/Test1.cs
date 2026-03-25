using Moq;

namespace Mock_Weekend.Test
{
    [TestClass]
    public sealed class GreeterTest
    {
        [TestMethod]
        [DataRow(DayOfWeek.Monday)]
        [DataRow(DayOfWeek.Tuesday)]
        [DataRow(DayOfWeek.Wednesday)]
        [DataRow(DayOfWeek.Thursday)]
        [DataRow(DayOfWeek.Friday)]
        public void Mock_GetDate_WeekDays_Returns_Correct_String(DayOfWeek day)
        {
            //Arrange
            var dateGetter = new Mock<IDateGetter>();
            dateGetter.Setup(x => x.GetDate()).Returns(day);
            var greeter = new Greeter(dateGetter.Object);
            //Action
            var result = greeter.GetMessage();
            //Assert
            Assert.AreEqual("Nog even het is bijna weekend", result);
        }


        [TestMethod]
        [DataRow(DayOfWeek.Saturday)]
        [DataRow(DayOfWeek.Sunday)]
        public void Mock_GetDate_Weekend_Returns_Correct_String(DayOfWeek day)
        {
            //Arrange
            var dateGetter = new Mock<IDateGetter>();
            dateGetter.Setup(x => x.GetDate()).Returns(day);
            var greeter = new Greeter(dateGetter.Object);
            //Action
            var result = greeter.GetMessage();
            //Assert
            Assert.AreEqual("Het is weekend", result);
        }
    }
}
