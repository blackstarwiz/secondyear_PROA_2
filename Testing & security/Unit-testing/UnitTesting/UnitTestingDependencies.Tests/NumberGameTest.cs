using Moq;
using UnitTestingDependencies;

[TestClass]
public class NumberGameTest
{
    [TestMethod]
    public void RateGuess_Returns_2_When_Guess_Is_Correct()
    {
        //Arrange
        var numberGame = new NumberGame(new DieMock(5));//We geven een voor gedefineerde dobbelsteen mee aan de numbergame
        //Act
        var result = numberGame.RateGuess(5);//Hier raden we of de dobbelsteen nu degelijk 5 is dus de function 'werkt'

        //Assert
        Assert.AreEqual(2, result);//Normaal zou deze true moeten terug geven (Groen worden in testing tabbel)
    }

    //Door dat we DieMock hebben gemaakt kunnen we verschillende situaaties testen met ons de function Numbergame

    [TestMethod]
    public void RateGuess_Returns_0_When_Guess_is_Wrong()
    {
        //Arrange
        var numberGame = new NumberGame(new DieMock(5));//We geven een voor gedefineerde dobbelsteen mee aan de numbergame
        //Act
        var result = numberGame.RateGuess(3);//Hier raden we of de dobbelsteen nu degelijk 5 is dus de function 'werkt'
        //We gaan er twee naast zitten dus moet result 0 terug geven
        //Assert
        Assert.AreEqual(0, result);//Normaal zou deze true moeten terug geven (Groen worden in testing tabbel)
    }

    [TestMethod]
    [DataRow(3)]
    [DataRow(5)]
    public void RateGuess_Returns_1_When_Guess_is_Only_1_Wrong(int input)
    {
        //Arrange
        var numberGame = new NumberGame(new DieMock(input));//We geven een voor gedefineerde dobbelsteen mee aan de numbergame
        //Act
        var result = numberGame.RateGuess(4);//Hier raden we of de dobbelsteen nu degelijk 5 is dus de function 'werkt'
        //We gaan er twee naast zitten dus moet result 0 terug geven
        //Assert
        Assert.AreEqual(1, result);//Normaal zou deze true moeten terug geven (Groen worden in testing tabbel)
    }

    //Gebruik van Moq framework

    [TestMethod]
    public void RateGuess_Returns_2_When_Guess_Is_Correct_Moq()
    {
        //Arrange
        var die = new Mock<IDie>();
        die.Setup(x => x.Roll()).Returns(5);//Spreek Roll() function aan en Returns de waarde 5 terug
        var numberGame = new NumberGame(die.Object);//Hier maken we een object van NumberGame aan die heb gemaaakt object van die gebruikt
        //Act
        var result = numberGame.RateGuess(5);
        //Assert
        Assert.AreEqual(2, result);
    }

    [TestMethod]
    public void Roll_Method_Rolls_The_Die_Exactly_Once()
    {
        var die = new Mock<IDie>();
        var numberGame = new NumberGame(die.Object);
        numberGame.RateGuess(5);
        die.Verify(x => x.Roll(), Times.Once);
    }
}