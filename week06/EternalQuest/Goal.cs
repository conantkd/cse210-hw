using System;
using System.Globalization;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("Goal names and descriptions cannot be empty.");
        }
        if (points < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points));
        }

        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _shortName;
    protected int GetPoints() => _points;

    public abstract long RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description})";
    }

    protected string GetBaseRepresentation()
    {
        return $"{Uri.EscapeDataString(_shortName)},{Uri.EscapeDataString(_description)},{_points.ToString(CultureInfo.InvariantCulture)}";
    }

    public static Goal FromStringRepresentation(string line)
    {
        string[] parts = line.Split(':', 2);
        if (parts.Length != 2)
        {
            throw new FormatException("Missing goal type.");
        }

        string[] fields = parts[1].Split(',');
        if (fields.Length < 3)
        {
            throw new FormatException("Missing goal fields.");
        }

        string name = Uri.UnescapeDataString(fields[0]);
        string description = Uri.UnescapeDataString(fields[1]);
        int points = int.Parse(fields[2], CultureInfo.InvariantCulture);

        return parts[0] switch
        {
            "SimpleGoal" when fields.Length == 4 => new SimpleGoal(
                name, description, points, bool.Parse(fields[3])),
            "EternalGoal" when fields.Length == 3 => new EternalGoal(
                name, description, points),
            "ChecklistGoal" when fields.Length == 6 => new ChecklistGoal(
                name, description, points,
                int.Parse(fields[4], CultureInfo.InvariantCulture),
                int.Parse(fields[3], CultureInfo.InvariantCulture),
                int.Parse(fields[5], CultureInfo.InvariantCulture)),
            _ => throw new FormatException("Unknown goal type or incorrect field count.")
        };
    }
}
