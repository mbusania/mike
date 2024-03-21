using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

// Base class for all types of goals
[Serializable]
abstract class Goal
{
    protected string name;
    protected int value;

    // Constructor
    public Goal(string name, int value)
    {
        this.name = name;
        this.value = value;
    }

    // Method to mark goal completion
    public abstract void Complete();

    // Method to get the status of the goal
    public abstract string GetStatus();
}

// Simple goal class
[Serializable]
class SimpleGoal : Goal
{
    // Constructor
    public SimpleGoal(string name, int value) : base(name, value)
    {
    }

    // Method overriding for completing the simple goal
    public override void Complete()
    {
        Console.WriteLine($"Completed simple goal: {name}. Gained {value} points.");
        // Add value to user's score
    }

    // Method overriding for getting the status of the simple goal
    public override string GetStatus()
    {
        return "[ ] " + name;
    }
}

// Eternal goal class
[Serializable]
class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    // Method overriding for completing the eternal goal
    public override void Complete()
    {
        Console.WriteLine($"Recorded progress for eternal goal: {name}. Gained {value} points.");
        // Add value to user's score
    }

    // Method overriding for getting the status of the eternal goal
    public override string GetStatus()
    {
        return "[X] " + name;
    }
}

// Checklist goal class
[Serializable]
class ChecklistGoal : Goal
{
    private int totalTimes;
    private int completedTimes;

    // Constructor
    public ChecklistGoal(string name, int value, int totalTimes) : base(name, value)
    {
        this.totalTimes = totalTimes;
        this.completedTimes = 0;
    }

    // Method overriding for completing the checklist goal
    public override void Complete()
    {
        completedTimes++;
        Console.WriteLine($"Completed {name} ({completedTimes}/{totalTimes}). Gained {value} points.");
        // Add value to user's score
        if (completedTimes == totalTimes)
        {
            Console.WriteLine($"Bonus! Checklist goal {name} completed {totalTimes} times. Gained extra {value * totalTimes} points.");
            // Add extra bonus value to user's score
        }
    }

    // Method overriding for getting the status of the checklist goal
    public override string GetStatus()
    {
        return $"Completed {completedTimes}/{totalTimes} times: {name}";
    }
}

// User class to manage goals and score
[Serializable]
class User
{
    public List<Goal> goals;
    public int score;

    // Constructor
    public User()
    {
        goals = new List<Goal>();
        score = 0;
    }

    // Method to add a new goal
    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    // Method to record completion of a goal
    public void RecordCompletion(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            goals[goalIndex].Complete();
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    // Method to display the list of goals
    public void DisplayGoals()
    {
        Console.WriteLine("Current Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
    }

    // Method to display the user's score
    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {score}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        User user = LoadUser();

        while (true)
        {
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. Add Goal");
            Console.WriteLine("2. Record Completion");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            int option;
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        Console.Write("Enter goal name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter goal type (1 for simple, 2 for eternal, 3 for checklist): ");
                        int type = int.Parse(Console.ReadLine());
                        Console.Write("Enter goal value: ");
                        int value = int.Parse(Console.ReadLine());
                        Goal goal = null;
                        switch (type)
                        {
                            case 1:
                                goal = new SimpleGoal(name, value);
                                break;
                            case 2:
                                goal = new EternalGoal(name, value);
                                break;
                            case 3:
                                Console.Write("Enter total times for checklist goal: ");
                                int totalTimes = int.Parse(Console.ReadLine());
                                goal = new ChecklistGoal(name, value, totalTimes);
                                break;
                            default:
                                Console.WriteLine("Invalid goal type.");
                                break;
                        }
                        if (goal != null)
                        {
                            user.AddGoal(goal);
                            Console.WriteLine("Goal added successfully.");
                        }
                        break;
                    case 2:
                        user.DisplayGoals();
                        Console.Write("Enter the index of
int index = int.Parse(Console.ReadLine()) - 1;
                        user.RecordCompletion(index);
                        break;
                    case 3:
                        user.DisplayGoals();
                        break;
                    case 4:
                        user.DisplayScore();
                        break;
                    case 5:
                        SaveUser(user);
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }

    static void SaveUser(User user)
    {
        try
        {
            FileStream fileStream = new FileStream("user.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, user);
            fileStream.Close();
            Console.WriteLine("User data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving user data: {ex.Message}");
        }
    }

    static User LoadUser()
    {
        User user = null;
        try
        {
            if (File.Exists("user.dat"))
            {
                FileStream fileStream = new FileStream("user.dat", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                user = (User)formatter.Deserialize(fileStream);
                fileStream.Close();
                Console.WriteLine("User data loaded successfully.");
            }
            else
            {
                user = new User();
                Console.WriteLine("New user created.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading user data: {ex.Message}");
        }
        return user ?? new User();
    }
}