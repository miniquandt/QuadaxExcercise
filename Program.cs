using System;
using System.Collections.Generic;

namespace QuadaxExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var mastermind = new Mastermind();
            Console.WriteLine("Welcome to Quadax's Programming Excerice!");
            Console.WriteLine("Would you like to play Mastermind? (y or n)");
            char yOrN = Console.ReadLine()[0];

            while (yOrN != 'n' && yOrN != 'N')
            {
                if (yOrN == 'y' || yOrN == 'Y')
                {
                    PlayMastermind(mastermind);
                }
                else
                {
                    Console.WriteLine("I'm sorry Please type 'y' for Yes or 'n' for No:");
                }

                Console.WriteLine("Would you like to play Mastermind? (y or n)");
                yOrN = Console.ReadLine()[0];
            }

            Console.WriteLine("Thank you for playing!");
        }

        public static void PlayMastermind(Mastermind m)
        {
            m.NewGame();

            var guessesPerRound = m.GetNumberOfPieces();
            var numberOfColors = m.GetNumberOfColors();

            Console.Clear();

                Console.WriteLine("Enter {0} seperate integers from 1-{1} representing your guesses:", guessesPerRound, numberOfColors);
            for (var i = 1; m.validGame(); i++)
            {
            var guesses = new List<int>();

                Console.WriteLine("Round {0}:", i);

                for (var j = 1; j <= guessesPerRound; j++)
                {
                    Console.Write("Guess {0}:", j);
                    var input = Console.ReadLine();

                    int.TryParse(input, out int result);
                    if (result < 1 || result > numberOfColors)
                    {
                        j--;
                        Console.WriteLine("I'm sorry that is an invalid guess, must be an int from 1-{0}", numberOfColors);
                    }
                    else{
                        guesses.Add(result);
                    }
                }

                Console.WriteLine("Round {0} Result:{1}",i, m.Guess(guesses));
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
