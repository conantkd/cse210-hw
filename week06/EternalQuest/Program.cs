// For exceding requirements: every 1,000 points earns a new level, with progress toward the next level and a celebration when leveling up.
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
