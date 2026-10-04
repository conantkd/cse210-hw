using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    public string Name => _name;
    public string Description => _description;

    public int Duration
    {
        get => _duration;
        set => _duration = Math.Max(0, value);
    }

    public void DisplayStartingMessage()
    {
        ClearScreenSafe();
        Console.WriteLine($"Welcome to the {_name} Activity!");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like your session to last? ");

        var input = Console.ReadLine();
        while (!int.TryParse(input, out int seconds) || seconds <= 0)
        {
            Console.Write("Please enter a positive number of seconds: ");
            input = Console.ReadLine();
        }

        Duration = int.Parse(input);
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage(int? elapsedSeconds = null)
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed the {_name} activity for {elapsedSeconds ?? _duration} seconds.");
        ShowSpinner(4);
    }

    private static void ClearScreenSafe()
    {
        try
        {
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }
        }
        catch (IOException)
        {
        }
    }

    public void ShowSpinner(int seconds)
    {
        var frames = new[] { "|", "/", "-", "\\" };
        var endTime = DateTime.Now.AddSeconds(seconds);
        var frameIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[frameIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            frameIndex = (frameIndex + 1) % frames.Length;
        }

        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        var endTime = DateTime.Now.AddSeconds(seconds);
        var previousLineLength = 0;

        while (DateTime.Now < endTime)
        {
            var remainingSeconds = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            var message = $"{remainingSeconds} second{(remainingSeconds == 1 ? "" : "s")} remaining...";
            Console.Write($"\r{message.PadRight(previousLineLength)}");
            previousLineLength = message.Length;
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }
}
