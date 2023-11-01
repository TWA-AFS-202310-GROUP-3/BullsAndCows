using BullsAndCows;
using Moq;
using System.Linq;
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
        public void Should_return_4A0B_when_guess_given_guess_all_corrects()
        {
            //Given
            string secretNumber = "1234";
            string guessNumber = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("4A0B", result);
        }

        [Fact]
        public void Should_return_0A0B_when_guess_given_guess_all_incorrect()
        {
            //Given
            string secretNumber = "1234";
            string guessNumber = "5678";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("0A0B", result);
        }

        [Theory]
        [InlineData("1256")]
        [InlineData("5634")]
        [InlineData("5236")]
        [InlineData("1564")]
        public void Should_return_2A0B_when_guess_given_guess_digit_value_and_position_partial_correct(string guessNumber)
        {
            //Given
            string secretNumber = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("2A0B", result);
        }

        [Theory]
        [InlineData("1562")]
        public void Should_return_1A1B_when_guess_given_guess_digit_value_and_position_partial_correct(string guessNumber)
        {
            //Given
            string secretNumber = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("1A1B", result);
        }

        [Theory]
        [InlineData("4321")]
        public void Should_return_0A4B_when_guess_given_guess_digit_position_all_incorrect(string guessNumber)
        {
            //Given
            string secretNumber = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("0A4B", result);
        }

        [Theory]
        [InlineData("1243")]
        public void Should_return_2A2B_when_guess_given_guess_digit_position_partial_correct(string guessNumber)
        {
            //Given
            string secretNumber = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("2A2B", result);
        }

        [Theory]
        [InlineData("5643")]
        public void Should_return_0A2B_when_guess_given_guess_digit_position_partial_correct(string guessNumber)
        {
            //Given
            string secretNumber = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("0A2B", result);
        }

        [Theory]
        [InlineData("56431")]
        [InlineData("564")]
        [InlineData("")]
        public void Should_print_warning_when_guess_given_input_length_incorrect(string guessNumber)
        {
            //Given
            string secretNumber = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("Wrong Input, input again", result);
        }

        [Theory]
        [InlineData("1123")]
        public void Should_print_warning_when_guess_given_input_contains_duplicates(string guessNumber)
        {
            //Given
            string secretNumber = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("Wrong Input, input again", result);
        }

        [Theory]
        [InlineData("123A")]
        public void Should_print_warning_when_guess_given_input_contains_non_digits(string guessNumber)
        {
            //Given
            string secretNumber = "1234";

            Mock<SecretGenerator> mockSecretGenerator = new Mock<SecretGenerator>();
            mockSecretGenerator.Setup(secret => secret.GenerateSecret()).Returns(secretNumber);

            var game = new BullsAndCowsGame(mockSecretGenerator.Object);

            //When
            string result = game.Guess(guessNumber);

            //Then
            Assert.Equal("Wrong Input, input again", result);
        }

        [Fact]
        public void Should_generate_4_digits_secretNumber_without_duplicate_number()
        {
            //Given
            var secretGenerator = new SecretGenerator();

            //When
            var secretNumber = secretGenerator.GenerateSecret();

            //Then
            Assert.Equal(4, secretNumber.Length);
            Assert.Equal(4, secretNumber.Distinct().Count());
        }

    }
}
