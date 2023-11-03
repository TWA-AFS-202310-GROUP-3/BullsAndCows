using System;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows
{
    public class BullsAndCowsGame
    {
        private readonly SecretGenerator secretGenerator;
        //private readonly string secret;
        private readonly string secretNumber;
        private readonly List<string> guesses;
        public BullsAndCowsGame(SecretGenerator secretGenerator)
        {
            //this.secretGenerator = secretGenerator;
            //secret = secretGenerator.GenerateSecret();
        }

        public BullsAndCowsGame()
        {
            secretNumber = GenerateSecretNumber();
            //Console.WriteLine("secretNumber: " + secretNumber);
            guesses = new List<string>();
        }

        public bool IsValidInput(string input)
        {
            //Console.WriteLine(input);
            return input.Length == 4 && input.All(char.IsDigit) && input.Distinct().Count() == 4;
        }

        public string MakeGuess(string guess)
        {
            if (!IsValidInput(guess))
            {
                return "Wrong Input, input again";
            }

            guesses.Add(guess);
            return Guess(guess);
        }

        //public bool CanContinue => true;

        public string Guess(string guess)
        {
            int bulls = 0;
            int cows = 0;
            //if (guess.Equals(secret))
            //{
            //    return "4A0B";
            //}
            //Console.WriteLine(secretNumber);

            for (int i = 0; i < 4; i++)
            {
                if (guess[i] == secretNumber[i])
                {
                    bulls++;
                }

                //else if (secretNumber.Contains(guess[i]))
                //{
                //    cows++;
                //}
            }

            for (int i = 0; i < 4; i++)
            {
                if (guess.IndexOf(secretNumber[i]) >= 0 && guess.IndexOf(secretNumber[i]) != i)
                {
                    cows++;
                }
            }

            return $"{bulls}A{cows}B";
        }

        public string GetGuessHistory()
        {
            return string.Join("\n", guesses.Select(g => $"{g} -> {Guess(g)}"));
        }

        public string ReturnSecretNumber()
        {
            return secretNumber;
        }

        private string GenerateSecretNumber()
        {
            Random rnd = new Random();
            //secretNumber = Enumerable.Range(0, 10).OrderBy(r => rnd.Next()).Take(4).Select(i => i.ToString()[0]).ToArray();
            //Console.WriteLine(Enumerable.Range(0, 10).OrderBy(r => rnd.Next()).Take(4).Select(i => i.ToString()[0]).ToArray());
            return new string(Enumerable.Range(0, 10).OrderBy(r => rnd.Next()).Take(4).Select(i => i.ToString()[0]).ToArray());
        }
    }
}