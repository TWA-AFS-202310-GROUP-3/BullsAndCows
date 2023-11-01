using System;
using System.Threading.Tasks.Sources;

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
            var bulls = 0;
            var cows = 0;
            //if (guess.Equals(secret))
            //{
            //    return "4A0B";
            //}

            for (var i = 0; i < secret.Length; i++)
            {
                if (guess[i] == secret[i])
                {
                    bulls++;
                }
            }

            for (int i = 0; i < secret.Length; i++)
            {
                if (guess.IndexOf(secret[i]) >= 0 && guess.IndexOf(secret[i]) != i)
                {
                    cows++;
                }
            }

            return $"{bulls}A{cows}B";
        }
    }
}