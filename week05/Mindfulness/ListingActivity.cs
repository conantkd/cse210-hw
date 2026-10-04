using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts;

    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        var randomPrompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine("List as many items as you can for the following prompt:");
        Console.WriteLine($"--- {randomPrompt} ---");
        Console.WriteLine("Take a moment to think...");
        ShowCountDown(5);

        var timer = Stopwatch.StartNew();
        var itemCount = 0;

        while (timer.Elapsed.TotalSeconds < Duration)
        {
            var remaining = Duration - (int)timer.Elapsed.TotalSeconds;
            Console.Write($"Enter an item ({Math.Max(0, remaining)} seconds remaining) or type 'done': ");
            var entry = ReadEntry(timer);
            if (entry == null || timer.Elapsed.TotalSeconds >= Duration)
            {
                break;
            }

            if (string.IsNullOrWhiteSpace(entry))
            {
                Console.WriteLine("Please enter an item or type 'done' to finish.");
                continue;
            }

            if (entry.Equals("done", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            itemCount++;
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {itemCount} items.");
        DisplayEndingMessage(Math.Min(Duration, (int)timer.Elapsed.TotalSeconds));
    }
    // Poll keys so the session ends even if the user has not pressed Enter.
    private string ReadEntry(Stopwatch timer)
    {
        var entry = new StringBuilder();
        while (timer.Elapsed.TotalSeconds < Duration)
        {
            if (Console.IsInputRedirected)
            {
                var readTask = Console.In.ReadLineAsync();
                var remaining = TimeSpan.FromSeconds(Math.Max(0, Duration - timer.Elapsed.TotalSeconds));
                return readTask.Wait(remaining) ? readTask.Result : null;
            }

            if (!Console.KeyAvailable)
            {
                Thread.Sleep(20);
                continue;
            }

            var key = Console.ReadKey(intercept: true);
            if (timer.Elapsed.TotalSeconds >= Duration)
            {
                break;
            }

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine();
                return entry.ToString();
            }

            if (key.Key == ConsoleKey.Backspace)
            {
                if (entry.Length > 0)
                {
                    entry.Length--;
                    Console.Write("\b \b");
                }
            }
            else if (!char.IsControl(key.KeyChar))
            {
                entry.Append(key.KeyChar);
                Console.Write(key.KeyChar);
            }
        }

        Console.WriteLine();
        return null;
    }
}
