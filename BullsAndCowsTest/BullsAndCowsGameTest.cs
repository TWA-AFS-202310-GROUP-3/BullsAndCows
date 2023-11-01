using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {

        [Fact]
        public void Should_return_4A0B_when_guess_given_guess_number_and_secret_same()
        {
            // Given
            string guessNumber = "1234";
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            // When
            string result = game.Guess(guessNumber);

            // Then
            Assert.Equal("4A0B", result);
        }
    }
}
