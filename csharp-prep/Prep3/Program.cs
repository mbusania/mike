using System;

namespace Prep3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a random magic number between 1 and 100
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            // Play the Guess My Number game
            int guess;
            do
            {
                // Ask the user for their guess
                Console.Write("What is your guess? ");
                guess = Convert.ToInt32(Console.ReadLine());

                // Check if the guess is higher, lower, or correct
                if (guess < magicNumber)
                    Console.WriteLine("Higher");
                else if (guess > magicNumber)
                    Console.WriteLine("Lower");
                else
                    Console.WriteLine("You guessed it!");
            } while (guess != magicNumber);
        }
    }
}
