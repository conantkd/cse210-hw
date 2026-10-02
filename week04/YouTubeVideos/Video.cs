using System;
using System.Collections.Generic;

class Video
{
    private List<Comment> _comments = new List<Comment>();

    public string Title { get; }
    public string Author { get; }
    public int DurationInSeconds { get; }

    public Video(string title, string author, int durationInSeconds)
    {
        Title = title;
        Author = author;
        DurationInSeconds = durationInSeconds;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Duration: {DurationInSeconds} seconds");
        Console.WriteLine($"Comments: {GetCommentCount()}");

        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"- {comment.UserName}: {comment.Text}");
        }
    }
}