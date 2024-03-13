using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    // Constructor that initializes the fraction to 1/1
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor that initializes the fraction with the given numerator and denominator to 1
    public Fraction(int numerator)
    {
        this.numerator = numerator;
        denominator = 1;
    }

    // Constructor that initializes the fraction with the given numerator and denominator
    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        if (denominator != 0)
            this.denominator = denominator;
        else
            throw new ArgumentException("Denominator cannot be zero.");
    }

    // Getter and setter for the numerator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    // Getter and setter for the denominator
    public int Denominator
    {
        get { return denominator; }
        set
        {
            if (value != 0)
                denominator = value;
            else
                throw new ArgumentException("Denominator cannot be zero.");
        }
    }

    // Method to return the fraction in the form "3/4"
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return the decimal value of the fraction
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances using all three constructors
        Fraction fraction1 = new Fraction();       // 1/1
        Fraction fraction2 = new Fraction(5);      // 5/1
        Fraction fraction3 = new Fraction(6, 7);   // 6/7

        // Displaying fractions
        Console.WriteLine(fraction1.GetFractionString());
        Console.WriteLine(fraction1.GetDecimalValue());
        Console.WriteLine(fraction2.GetFractionString());
        Console.WriteLine(fraction2.GetDecimalValue());
        Console.WriteLine(fraction3.GetFractionString());
        Console.WriteLine(fraction3.GetDecimalValue());
    }
}
