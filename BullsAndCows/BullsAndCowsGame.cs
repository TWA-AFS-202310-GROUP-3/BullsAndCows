using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        private readonly string secret;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
            secret = secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            int bulls = 0;
            int cows = 0;
            if (guess.Equals(secret))
            {
                return "4A0B";
            }

            for (int i = 0; i < secret.Length; i++)
            {
                if (guess[i] == secret[i]) //compare the i th element in the string
                {
                    bulls++;
                }
            }

            for (int i = 0; i < secret.Length; i++)
            {
                if (guess.IndexOf(secret[i]) >= 0 && guess.IndexOf(secret[i]) != i) // has matched number && number not in the correct position(not equal to i)
                {
                    cows++;
                }
            }

            return $"{bulls}A{cows}B"; //$ means can be changed
        }
    }
}