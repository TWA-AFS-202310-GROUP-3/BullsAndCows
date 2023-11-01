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

        [Theory]
        [InlineData("1256")]
        [InlineData("5634")]
        [InlineData("5236")]
        [InlineData("1564")]
        public void Should_return_2A0B_when_guess_given_position_and_digit_partial_correct(string guessNumber)
        {
            // Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            // When
            string result = game.Guess(guessNumber);

            // Then
            Assert.Equal("2A0B", result);
        }

        [Theory]
        [InlineData("1389")]
        [InlineData("8249")]
        [InlineData("8932")]
        [InlineData("8914")]
        public void Should_return_1A1B_when_guess_given_position_and_digit_partial_correct(string guessNumber)
        {
            // Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            // When
            string result = game.Guess(guessNumber);

            // Then
            Assert.Equal("1A1B", result);
        }

        [Theory]
        [InlineData("3489")]
        [InlineData("8149")]
        [InlineData("8912")]
        [InlineData("4891")]
        public void Should_return_0A2B_when_guess_given_position_and_digit_partial_correct(string guessNumber)
        {
            // Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            // When
            string result = game.Guess(guessNumber);

            // Then
            Assert.Equal("0A2B", result);
        }

        [Theory]
        [InlineData("1243")]
        [InlineData("1324")]
        [InlineData("2134")]
        [InlineData("3214")]
        public void Should_return_2A2B_when_guess_given_digit_correct_but_positon_partial_correct(string guessNumber)
        {
            // Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            // When
            string result = game.Guess(guessNumber);

            // Then
            Assert.Equal("2A2B", result);
        }

        [Theory]
        [InlineData("2341")]
        [InlineData("3412")]
        [InlineData("4123")]
        [InlineData("2143")]
        public void Should_return_0A4B_when_guess_given_values_correct_but_position_all_incorrect(string guessNumber)
        {
            // Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(generator => generator.GenerateSecret()).Returns(secret);

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);

            // When
            string result = game.Guess(guessNumber);

            // Then
            Assert.Equal("0A4B", result);
        }
    }
}
