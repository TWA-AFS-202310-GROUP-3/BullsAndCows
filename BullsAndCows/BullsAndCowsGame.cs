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
            else
            {
                int bulls = GetCorrectPositionDigitAmount(guess);
                return $"{bulls}A0B";
            }

            return string.Empty;
        }

        private int GetCorrectPositionDigitAmount(string guess)
        {
            int count = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i].Equals(secretNumber[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}