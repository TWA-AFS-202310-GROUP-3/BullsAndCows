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
        public void Should_return_4A0B_When_guess_Given_input_number_same_with_secret()
        {
            //Given
            string guess = "1234";
            string secret = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guess);

            //Then
            Assert.Equal("4A0B", result);
        }

        [Theory]
        [InlineData("1256")]
        [InlineData("5734")]
        public void Should_return_2A0B_When_guess_Given_digits_values_partially_correct_positions_partially_correct(string guess)
        {
            //Given
            //string guess = "1256";
            string secret = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guess);

            //Then
            Assert.Equal("2A0B", result);
        }
    }
}
