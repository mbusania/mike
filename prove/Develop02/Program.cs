using System;
using System.Collections.Generic;
using System.IO;

// Journal class to manage entries
class Journal
{
    private List<Entry> _entries = new List<Entry>();

    // Method to add a new entry
    public void AddEntry(string prompt, string response)
    {
        string date = DateTime.Now.ToString("MM/dd/yyyy");
        Entry newEntry = new Entry(prompt, response, date);
        _entries.Add(newEntry);
    }

    // Method to display all entries
    public void DisplayEntries()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    // Method to save entries to a file
    public void SaveToFile(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                sw.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
    }

    // Method to load entries from a file
    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        using (StreamReader sr = new StreamReader(filename))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    AddEntry(parts[1], parts[2]);
                }
            }
        }
    }
}

// Entry class to represent a journal entry
class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public string Date { get; }

    // Constructor
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Method to display the entry
    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    // Mocking prompt selection
                    string prompt = GetRandomPrompt();
                    journal.AddEntry(prompt, response);
                    break;
                case "2":
                    Console.WriteLine("Journal Entries:");
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine("Journal saved successfully.");
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    Console.WriteLine("Journal loaded successfully.");
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Method to get a random prompt
    static string GetRandomPrompt()
    {
        List<string> prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        Random rnd = new Random();
        return prompts[rnd.Next(prompts.Count)];
    }
}
