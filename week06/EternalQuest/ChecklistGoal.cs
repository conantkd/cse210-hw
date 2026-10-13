using System;
using System.Globalization;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target,
        int bonus, int amountCompleted = 0) : base(name, description, points)
    {
        if (target <= 0 || bonus < 0 || amountCompleted < 0 || amountCompleted > target)
        {
            throw new ArgumentException("Invalid checklist target, bonus, or progress.");
        }

        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override long RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _amountCompleted++;
        return (long)GetPoints() + (IsComplete() ? _bonus : 0);
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return string.Format(CultureInfo.InvariantCulture,
            "ChecklistGoal:{0},{1},{2},{3}", GetBaseRepresentation(), _bonus, _target, _amountCompleted);
    }
}
