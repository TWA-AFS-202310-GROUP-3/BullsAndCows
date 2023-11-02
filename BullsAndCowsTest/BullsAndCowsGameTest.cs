using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        /*[Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }*/

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

        [Theory]
        [InlineData("1256")] //replace the input of string guess
        [InlineData("1974")]
        public void Should_return_2A0B_given_Guess_when_position_and_digit_partially_right(string guess)
        {
            //Given
            /*string guess = "1234";*/
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(s => s.GenerateSecret()).Returns(secret);
            //set up mockedSecretGenerator, return (secret) when use GenerateSecret() method

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //When
            string result = game.Guess(guess);
            //Then
            Assert.Equal("2A0B", result);
        }

        [Theory]
        [InlineData("1396")]
        [InlineData("2904")]
        public void Should_return_1A1B_given_Guess_when_position_and_digit_partially_right(string guess)
        {
            //Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(s => s.GenerateSecret()).Returns(secret);
            //set up mockedSecretGenerator, return (secret) when use GenerateSecret() method

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //When
            string result = game.Guess(guess);
            //Then
            Assert.Equal("1A1B", result);
        }

        [Theory]
        [InlineData("7809")]
        public void Should_return_0A0B_given_Guess_when_all_position_and_digit_incorrect(string guess)
        {
            //Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(s => s.GenerateSecret()).Returns(secret);
            //set up mockedSecretGenerator, return (secret) when use GenerateSecret() method

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //When
            string result = game.Guess(guess);
            //Then
            Assert.Equal("0A0B", result);
        }

        [Theory]
        [InlineData("4321")]
        public void Should_return_0A4B_given_Guess_when_all_digit_correct_and_position_incorrect(string guess)
        {
            //Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(s => s.GenerateSecret()).Returns(secret);
            //set up mockedSecretGenerator, return (secret) when use GenerateSecret() method

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //When
            string result = game.Guess(guess);
            //Then
            Assert.Equal("0A4B", result);
        }

        [Theory]
        [InlineData("1324")]
        public void Should_return_2A2B_given_Guess_when_all_digit_correct_and_position_partially_incorrect(string guess)
        {
            //Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(s => s.GenerateSecret()).Returns(secret);
            //set up mockedSecretGenerator, return (secret) when use GenerateSecret() method

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //When
            string result = game.Guess(guess);
            //Then
            Assert.Equal("2A2B", result);
        }

        [Theory]
        [InlineData("4198")]
        public void Should_return_0A2B_given_Guess_when_digit_partially_correct_and_all_position_incorrect(string guess)
        {
            //Given
            string secret = "1234";

            Mock<SecretGenerator> mockedSecretGenerator = new Mock<SecretGenerator>();
            mockedSecretGenerator.Setup(s => s.GenerateSecret()).Returns(secret);
            //set up mockedSecretGenerator, return (secret) when use GenerateSecret() method

            var game = new BullsAndCowsGame(mockedSecretGenerator.Object);
            //When
            string result = game.Guess(guess);
            //Then
            Assert.Equal("0A2B", result);
        }
    }
}
