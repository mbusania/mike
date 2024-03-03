using System;
using System.Collections.Generic;
using System.Linq;

namespace Prep4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            // Ask the user for a series of numbers until they enter 0
            int number;
            do
            {
                Console.Write("Enter number: ");
                number = Convert.ToInt32(Console.ReadLine());
                if (number != 0)
                    numbers.Add(number);
            } while (number != 0);

            // Compute the sum of the numbers
            int sum = numbers.Sum();

            // Compute the average of the numbers
            double average = numbers.Average();

            
            int max = numbers.Max();

            
            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");
        }
    }
}
