using System;
using BullsAndCows;

namespace BullsAndCowsRunner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //SecretGenerator secretGenerator = new SecretGenerator();
            //BullsAndCowsGame game = new BullsAndCowsGame(secretGenerator);
            //while (game.CanContinue)
            //{
            //    var input = Console.ReadLine();
            //    var output = game.Guess(input);
            //    Console.WriteLine(output);
            //}

            //Console.WriteLine("Game Over");

            BullsAndCowsGame game = new BullsAndCowsGame();
            Console.WriteLine("Welcome to Bulls and Cows game!");

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Please enter your guess:");
                string guess = Console.ReadLine();
                string result = game.MakeGuess(guess);

                if (result == "4A0B")
                {
                    Console.WriteLine("Congratulations! You guessed the right number!");
                    Console.WriteLine("Secret number is: " + game.ReturnSecretNumber());
                    break;
                }
                else
                {
                    Console.WriteLine(result);
                    //Console.WriteLine("Your guesses so far:");
                    Console.WriteLine(game.GetGuessHistory());
                }
            }

            Console.WriteLine("Game over!");
            Console.WriteLine("Secret number is: " + game.ReturnSecretNumber());
        }
    }
}