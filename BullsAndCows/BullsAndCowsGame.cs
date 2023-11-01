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
            int bulls = GetCorrectPositionDigitAmount(guess);
            int cows = GetIncorrectPositionDigitAmount(guess);
            return $"{bulls}A{cows}B";
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

        private int GetIncorrectPositionDigitAmount(string guess)
        {
            int count = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                var index = secretNumber.IndexOf(guess[i]);
                if (index >= 0 && index != i)
                {
                    count++;
                }
            }

            return count;
        }
    }
}