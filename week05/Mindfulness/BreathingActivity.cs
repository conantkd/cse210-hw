using System;
using System.Collections.Generic;

public class BreathingActivity : Activity
{
    private readonly List<string> _prompts;

    public BreathingActivity() : base(
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _prompts = new List<string>
        {
            "Breathe in...",
            "Breathe out..."
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        var elapsedSeconds = 0;

        while (elapsedSeconds < Duration)
        {
            foreach (var prompt in _prompts)
            {
                if (elapsedSeconds >= Duration)
                {
                    break;
                }

                Console.WriteLine();
                Console.WriteLine(prompt);

                var pauseLength = Math.Min(4, Duration - elapsedSeconds);
                ShowCountDown(pauseLength);
                elapsedSeconds += pauseLength;
            }
        }

        DisplayEndingMessage();
    }
}
