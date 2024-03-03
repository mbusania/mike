using System;

namespace Prep5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call DisplayWelcome function
            DisplayWelcome();

            // Call PromptUserName function
            string userName = PromptUserName();

            // Call PromptUserNumber function
            int userNumber = PromptUserNumber();

            // Call SquareNumber function
            int squaredNumber = SquareNumber(userNumber);

            // Call DisplayResult function
            DisplayResult(userName, squaredNumber);
        }

        // Function to display welcome message
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        // Function to prompt user for name and return it
        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            return Console.ReadLine();
        }

        // Function to prompt user for number and return it
        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        // Function to square a number
        static int SquareNumber(int number)
        {
            return number * number;
        }

        // Function to display result
        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        }
    }
}
