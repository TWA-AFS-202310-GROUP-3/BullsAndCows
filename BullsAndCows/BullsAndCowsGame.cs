using System;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            this.secretGenerator = secretGenerator;
        }

        public string GetSecret()
        {
            return this.secretGenerator.GenerateSecret();
        }

        public bool CanContinue => true;

        public string Guess(string guess)
        {
            var secret = GetSecret();
            var bulls = 0;
            var cows = 0;

            if (secret.Equals(guess))
            {
                return "4A0B";
            }

            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == secret[i])
                {
                    bulls++;
                }

                if (guess.IndexOf(secret[i]) >= 0 && guess.IndexOf(secret[i]) != i)
                {
                    cows++;
                }
            }

            return $"{bulls}A{cows}B";
        }
    }
}