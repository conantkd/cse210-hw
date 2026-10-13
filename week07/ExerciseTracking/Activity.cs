using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;
    private string _name;

    public Activity(DateTime date, int minutes, string name)
    {
        _date = date;
        _minutes = minutes;
        _name = name;
    }

    protected int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {_name} ({_minutes} min): " +
            $"Distance: {GetDistance():F1} km, Speed: {GetSpeed():F1} km/h, " +
            $"Pace: {GetPace():F2} min per km";
    }
}
