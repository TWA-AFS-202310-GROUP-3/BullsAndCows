using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly string secretNumber;
        private readonly SecretGenerator secretGenerator;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            secretNumber = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            if (guess.Equals(secretNumber))
            {
                return "4A0B";
            }

            return string.Empty;
        }
    }
}