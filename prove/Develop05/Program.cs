using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public abstract class Goal
{
    private string _name;
    private int _points;

    public Goal(string name)
    {
        _name = name;
        _points = 0;
    }

    public string Name { get { return _name; } }
    public int Points { get { return _points; } }

    public abstract void RecordProgress();

    public virtual void DisplayGoal()
    {
        Console.WriteLine($"Goal: {_name} | Points: {_points}");
    }

    public virtual string SerializeGoal()
    {
        return $"{_name},{_points}";
    }

    public virtual void DeserializeGoal(string data)
    {
        string[] parts = data.Split(',');
        _name = parts[0];
        _points = int.Parse(parts[1]);
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name) : base(name)
    {
    }

    public override void RecordProgress()
    {
        base._points += 1000;
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name) : base(name)
    {
    }

    public override void RecordProgress()
    {
        base._points += 100;
    }
}

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _completedCount;

    public ChecklistGoal(string name, int targetCount) : base(name)
    {
        _targetCount = targetCount;
        _completedCount = 0;
    }

    public override void RecordProgress()
    {
        base._points += 50;
        _completedCount++;

        if (_completedCount == _targetCount)
        {
            base._points += 500;
        }
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Goal: {_name} | Points: {_points} | Completed: {_completedCount}/{_targetCount} times");
    }
}

class Program
{
    static List<Goal> goals = new List<Goal>();

    static void Main(string[] args)
    {
        LoadGoals(); // Load previously saved goals

        SimpleGoal marathonGoal = new SimpleGoal("Run a marathon");
        marathonGoal.RecordProgress();
        marathonGoal.DisplayGoal();
        goals.Add(marathonGoal);

        EternalGoal scripturesGoal = new EternalGoal("Read scriptures daily");
        scripturesGoal.RecordProgress();
        scripturesGoal.DisplayGoal();
        goals.Add(scripturesGoal);

        ChecklistGoal templeGoal = new ChecklistGoal("Attend temple", 10);
        templeGoal.RecordProgress();
        templeGoal.RecordProgress();
        templeGoal.DisplayGoal();
        goals.Add(templeGoal);

        SaveGoals(); // Save goals after recording progress
    }

    static void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter("goals.txt"))
        {
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.SerializeGoal());
            }
        }
    }

    static void LoadGoals()
    {
        if (File.Exists("goals.txt"))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string name = parts[0];
                int points = int.Parse(parts[1]);

                if (name == "Run a marathon")
                    goals.Add(new SimpleGoal(name));
                else if (name == "Read scriptures daily")
                    goals.Add(new EternalGoal(name));
                else if (name == "Attend temple")
                    goals.Add(new ChecklistGoal(name, 10));

                goals.Last().DeserializeGoal(line);
            }
        }
    }
}
