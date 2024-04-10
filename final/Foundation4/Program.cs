using System;
using System.Collections.Generic;

class Activity
{
    public DateTime Date { get; set; }
    public int LengthInMinutes { get; set; }

    public virtual double GetDistance()
    {
        return 0; // Default implementation for activities without a specific distance
    }

    public virtual double GetSpeed()
    {
        return 0; // Default implementation for activities without a specific speed
    }

    public virtual string GetSummary()
    {
        return $"{Date.ToShortDateString()} {GetType().Name} ({LengthInMinutes} min)";
    }
}

class Running : Activity
{
    public double Distance { get; set; }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return Distance / (LengthInMinutes / 60.0);
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {Distance} miles, Speed: {GetSpeed()} mph, Pace: {60.0 / GetSpeed()} min per mile";
    }
}

class Cycling : Activity
{
    public double Speed { get; set; }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Speed: {Speed} mph, Pace: {60.0 / Speed} min per mile";
    }
}

class Swimming : Activity
{
    public int Laps { get; set; }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0; // Convert laps to kilometers
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} - Distance: {GetDistance()} km";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running
        {
            Date = new DateTime(2024, 11, 3),
            LengthInMinutes = 30,
            Distance = 3.0
        };
        activities.Add(running);

        Cycling cycling = new Cycling
        {
            Date = new DateTime(2024, 11, 3),
            LengthInMinutes = 30,
            Speed = 12.0
        };
        activities.Add(cycling);

        Swimming swimming = new Swimming
        {
            Date = new DateTime(2024, 11, 3),
            LengthInMinutes = 30,
            Laps = 20
        };
        activities.Add(swimming);

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
