using System;

// Base class for all types of assignments
public class Assignment
{
    // Private member variables
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to return a summary of the assignment
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}

// Derived class for Math assignments
public class MathAssignment : Assignment
{
    // Private member variables specific to MathAssignment
    private string _textbookSection;
    private string _problems;

    // Constructor
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) 
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Method to get the homework list for MathAssignment
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}

// Derived class for Writing assignments
public class WritingAssignment : Assignment
{
    // Private member variables specific to WritingAssignment
    private string _assignmentTitle;

    // Constructor
    public WritingAssignment(string studentName, string topic, string assignmentTitle) 
        : base(studentName, topic)
    {
        _assignmentTitle = assignmentTitle;
    }

    // Method to get writing information for WritingAssignment
    public string GetWritingInformation()
    {
        return $"{_assignmentTitle} by {_studentName}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Test MathAssignment
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // Test WritingAssignment
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}
