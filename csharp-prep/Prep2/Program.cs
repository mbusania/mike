using System;

namespace Prep2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask the user for their grade percentage
            Console.Write("Enter your grade percentage: ");
            int gradePercentage = Convert.ToInt32(Console.ReadLine());

            // Determine the letter grade
            char letter;

            if (gradePercentage >= 90)
                letter = 'A';
            else if (gradePercentage >= 80)
                letter = 'B';
            else if (gradePercentage >= 70)
                letter = 'C';
            else if (gradePercentage >= 60)
                letter = 'D';
            else
                letter = 'F';

            // Display the letter grade
            Console.WriteLine($"Your letter grade is: {letter}");

            // Check if the user passed the course
            if (letter != 'F')
                Console.WriteLine("Congratulations! You passed the course.");
            else
                Console.WriteLine("Don't worry, you can try again next time.");
        }
    }
}
