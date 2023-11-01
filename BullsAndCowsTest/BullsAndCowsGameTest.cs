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
            string secret = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guess);

            //Then
            Assert.Equal("2A0B", result);
        }

        [Theory]
        [InlineData("1625")]
        [InlineData("1783")]
        public void Should_return_1A1B_When_guess_Given_digits_values_partially_correct_positions_partially_correct(string guess)
        {
            //Given
            string secret = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guess);

            //Then
            Assert.Equal("1A1B", result);
        }

        [Theory]
        [InlineData("5678")]
        [InlineData("6789")]
        public void Should_return_0A0B_When_guess_Given_all_digits_values_positions_incorrect(string guess)
        {
            //Given
            string secret = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guess);

            //Then
            Assert.Equal("0A0B", result);
        }

        [Theory]
        [InlineData("4321")]
        [InlineData("3421")]
        public void Should_return_0A4B_When_guess_Given_digits_all_values_correct_all_positions_incorrect(string guess)
        {
            //Given
            string secret = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guess);

            //Then
            Assert.Equal("0A4B", result);
        }

        [Theory]
        [InlineData("1243")]
        [InlineData("2134")]
        public void Should_return_2A2B_When_guess_Given_digits_all_values_correct_partially_positions_correct(string guess)
        {
            //Given
            string secret = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guess);

            //Then
            Assert.Equal("2A2B", result);
        }

        [Theory]
        [InlineData("5643")]
        [InlineData("2178")]
        public void Should_return_0A2B_When_guess_Given_digits_partially_values_correct_all_positions_incorrect(string guess)
        {
            //Given
            string secret = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(m => m.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guess);

            //Then
            Assert.Equal("0A2B", result);
        }
    }
}
