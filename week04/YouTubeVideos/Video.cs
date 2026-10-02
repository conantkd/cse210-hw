using System;
using System.Collections.Generic;

class Video
{
    private string _title;
    private string _author;
    private int _durationInSeconds;
    private List<Comment> _comments = new List<Comment>();

    public string Title { get { return _title; } }
    public string Author { get { return _author; } }
    public int DurationInSeconds { get { return _durationInSeconds; } }

    public Video(string title, string author, int durationInSeconds)
    {
        _title = title;
        _author = author;
        _durationInSeconds = durationInSeconds;
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