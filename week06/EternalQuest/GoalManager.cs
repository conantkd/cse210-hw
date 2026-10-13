using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private long _score = 0;
    private const int PointsPerLevel = 1000;

    public void Start()
    {
        Console.WriteLine("Welcome to Eternal Quest!");
        while (true)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            switch (ReadNumber("Select a choice from the menu: ", 1, 6))
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6:
                    Console.WriteLine("Keep moving forward on your Eternal Quest!");
                    return;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level {GetLevel()} | {PointsPerLevel - _score % PointsPerLevel} points to the next level.");
        Console.WriteLine();
    }

    private long GetLevel() => _score / PointsPerLevel + 1;

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet. Create a goal to get started.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        int type = ReadNumber("Which type of goal would you like to create? ", 1, 3);
        string name = ReadText("What is the name of your goal? ");
        string description = ReadText("What is a short description of it? ");
        int points = ReadNumber("How many points is this goal worth? ", 0);

        Goal goal;
        if (type == 1)
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (type == 2)
        {
            goal = new EternalGoal(name, description, points);
        }
        else
        {
            int target = ReadNumber("How many times must this goal be accomplished for a bonus? ", 1);
            int bonus = ReadNumber("What is the bonus for accomplishing it that many times? ", 0);
            goal = new ChecklistGoal(name, description, points, target, bonus);
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        Console.WriteLine("The goals are:");
        ListGoalNames();
        int index = ReadNumber("Which goal did you accomplish? ", 1, _goals.Count) - 1;
        Goal goal = _goals[index];
        if (goal.IsComplete())
        {
            Console.WriteLine("That goal is already complete. No additional points were awarded.");
            return;
        }
        if (_score > long.MaxValue - 2L * int.MaxValue)
        {
            Console.WriteLine("The score has reached its supported limit.");
            return;
        }

        long previousLevel = GetLevel();
        long earned = goal.RecordEvent();
        _score += earned;
        Console.WriteLine($"Congratulations! You earned {earned} points!");
        if (goal.IsComplete())
        {
            Console.WriteLine($"Goal complete: {goal.GetName()}!");
        }
        if (GetLevel() > previousLevel)
        {
            Console.WriteLine($"*** LEVEL UP! You reached level {GetLevel()}! ***");
        }
        DisplayPlayerInfo();
    }

    public void SaveGoals()
    {
        string filename = ReadText("What is the filename for the goal file? ");
        var lines = new List<string> { _score.ToString(CultureInfo.InvariantCulture) };
        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        File.WriteAllLines(filename, lines);
        Console.WriteLine($"Goals saved to {filename}.");
    }

    public void LoadGoals()
    {
        string filename = ReadText("What is the filename for the goal file? ");
        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        if (lines.Length == 0 || !long.TryParse(lines[0], NumberStyles.Integer,
            CultureInfo.InvariantCulture, out long score) || score < 0)
        {
            Console.WriteLine("The file must begin with a nonnegative score.");
            return;
        }

        var loadedGoals = new List<Goal>();
        for (int i = 1; i < lines.Length; i++)
        {
            loadedGoals.Add(Goal.FromStringRepresentation(lines[i]));
        }

        _goals = loadedGoals;
        _score = score;
        Console.WriteLine($"Loaded {_goals.Count} goals and {_score} points.");
    }

    private static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (input == null)
            {
                throw new EndOfStreamException();
            }
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            Console.WriteLine("Please enter a value.");
        }
    }

    private static int ReadNumber(string prompt, int minimum, int maximum = int.MaxValue)
    {
        while (true)
        {
            string input = ReadText(prompt);
            if (int.TryParse(input, out int number) && number >= minimum && number <= maximum)
            {
                return number;
            }
            Console.WriteLine($"Please enter a whole number from {minimum} to {maximum}.");
        }
    }
}
