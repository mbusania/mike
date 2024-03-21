using System;
using System.Threading;

// Base class for all activities
class MindfulnessActivity
{
    protected static int activityCount = 0;

    protected string name;
    protected string description;
    protected int durationInSeconds;

    public MindfulnessActivity(string name, string description)
    {
        this.name = name;
        this.description = description;
        activityCount++;
    }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {name} activity...");
        Console.WriteLine(description);
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    public virtual void EndActivity()
    {
        Console.WriteLine($"You've completed {name} activity.");
        Console.WriteLine($"Duration: {durationInSeconds} seconds");
        Console.WriteLine($"Number of times performed: {activityCount}");
        Thread.Sleep(3000); // Pause for 3 seconds
    }
}

// Breathing activity class
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(string name, string description) : base(name, description)
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly.");
        Console.WriteLine("Clear your mind and focus on your breathing.");
        Console.WriteLine("Breathe in...");
        Thread.Sleep(3000); // Pause for 3 seconds
        Console.WriteLine("Breathe out...");
        Thread.Sleep(3000); // Pause for 3 seconds
        // Implement breathing in and out messages with countdown
    }
}

// Reflection activity class
class ReflectionActivity : MindfulnessActivity
{
    public ReflectionActivity(string name, string description) : base(name, description)
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");
        // Select random prompt and display questions with countdown
        Random random = new Random();
        string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        foreach (string prompt in prompts)
        {
            Console.WriteLine(prompt);
            Thread.Sleep(3000);
            // Display reflection questions with countdown
        }
    }
}

// Listing activity class
class ListingActivity : MindfulnessActivity
{
    public ListingActivity(string name, string description) : base(name, description)
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        // Select random prompt and display countdown to start listing
        Random random = new Random();
        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        
        string randomPrompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(randomPrompt);
        Thread.Sleep(3000);
        Console.WriteLine("Start listing...");
        // Allow user to list items until durationInSeconds is reached
        Thread.Sleep(durationInSeconds * 1000); // Pause for durationInSeconds
    }
}

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathingActivity = new BreathingActivity("Breathing", "This activity will help you relax by walking you through breathing in and out slowly.");
        breathingActivity.StartActivity();
        breathingActivity.EndActivity();

        ReflectionActivity reflectionActivity = new ReflectionActivity("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.");
        reflectionActivity.StartActivity();
        reflectionActivity.EndActivity();

        ListingActivity listingActivity = new ListingActivity("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        listingActivity.StartActivity();
        listingActivity.EndActivity();
    }
}
