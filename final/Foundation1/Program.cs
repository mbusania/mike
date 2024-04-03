using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(string commenterName, string commentText)
    {
        comments.Add(new Comment(commenterName, commentText));
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {LengthInSeconds} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
        }
    }
}

class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Introduction to Programming", "John Doe", 600);
        video1.AddComment("Alice", "Great video!");
        video1.AddComment("Bob", "Very helpful!");
        videos.Add(video1);

        Video video2 = new Video("Data Structures Explained", "Jane Smith", 720);
        video2.AddComment("Charlie", "I didn't understand this part.");
        videos.Add(video2);

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
            Console.WriteLine();
        }
    }
}
