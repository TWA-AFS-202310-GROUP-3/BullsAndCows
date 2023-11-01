using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_4A0B_given_Guess_when_secret_and_guess_same()
        {
            //Given
            string guess = "1234";
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(s => s.GenerateSecret()).Returns(secret);
            //set up mockedSecretGenerator, return (secret) when use GenerateSecret() method

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //When
            string result = game.Guess(guess);
            //Then
            Assert.Equal("4A0B", result);
        }

        [Fact]
        public void Should_return_2A0B_given_Guess_when_position_and_digit_partial_right()
        {
            //Given
            string guess = "1234";
            string secret = "1256";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(s => s.GenerateSecret()).Returns(secret);
            //set up mockedSecretGenerator, return (secret) when use GenerateSecret() method

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //When
            string result = game.Guess(guess);
            //Then
            Assert.Equal("2A0B", result);
        }
    }
}
