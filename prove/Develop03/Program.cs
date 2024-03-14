using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a Scripture object
        var scripture = new Scripture("John 3:16", "For God so loved the world...");

        // Display the scripture
        Console.WriteLine(scripture.GetDisplayText());

        // Loop until all words are hidden or user types "quit"
        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            // Hide a random word
            scripture.HideRandomWords(1);

            // Clear console and display updated scripture
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}

public class Scripture
{
    private string _reference;
    private List<Word> _words;

    public Scripture(string reference, string text)
    {
        _reference = reference;
        _words = ExtractWords(text);
    }

    private List<Word> ExtractWords(string text)
    {
        string[] wordArray = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return wordArray.Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsCount = _words.Count;
        for (int i = 0; i < numberToHide; i++)
        {
            int randomIndex = random.Next(0, wordsCount);
            _words[randomIndex].Hide();
        }
    }

    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(word => word.GetDisplayText()));
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}
