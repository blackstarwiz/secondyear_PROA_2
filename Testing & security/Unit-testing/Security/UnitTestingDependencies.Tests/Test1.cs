using Castle.Components.DictionaryAdapter.Xml;
using Moq;

namespace UnitTestingDependencies.Tests
{
    [TestClass]
    public sealed class NumberGameTest
    {
        [TestMethod]
        public void RateGuess_Returns_2_When_Guess_Correct()
        {
            //Arrange
            NumberGame game = new NumberGame(new Die());
            //Action
            var result = game.RateGuess(5);
            //Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Mock_RateGuess_Returns_2_When_Guess_Correct()
        {
            //Arrange
            //gebruik mock om type IDie mee tegeven
            var die = new Mock<IDie>();
            //de setup zal de methode Roll() aanspreken en het getal 5 terug geven
            die.Setup(x => x.Roll()).Returns(5);
            //start de game door een klasse init te doen die het object die mee krijgt met 5 als result
            var game = new NumberGame(die.Object);
            
            //Action
            //We gaan nu rategeuss() met een waarde  meegeven
            var result = game.RateGuess(5);
            
            //Assert
            Assert.AreEqual(2,result);
        }

        [TestMethod]
        public void Roll_Methode_Rolls_The_Die_Once()
        {
            //Arrange
            //maak een mock die
            var die = new Mock<IDie>();
            //init numbergame()
            var game = new NumberGame(die.Object);
            //Action
            game.RateGuess(5);
            //Assert
            die.Verify(x => x.Roll(), Times.Once);
        }
    }
}