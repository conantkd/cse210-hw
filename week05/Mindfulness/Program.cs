// For exceding the requirements the program tracks completed sessions per activity and showing the totals in the menu.
using System;
using System.Collections.Generic;

class Program
{
    private static readonly Dictionary<string, int> _activityCounts = new()
    {
        ["Breathing"] = 0,
        ["Reflection"] = 0,
        ["Listing"] = 0
    };

    static void Main(string[] args)
    {
        while (true)
        {
            ClearScreenSafe();
            Console.WriteLine("Mindfulness Activities");
            Console.WriteLine($"1. Breathing Activity (completed: {_activityCounts["Breathing"]})");
            Console.WriteLine($"2. Reflection Activity (completed: {_activityCounts["Reflection"]})");
            Console.WriteLine($"3. Listing Activity (completed: {_activityCounts["Listing"]})");
            Console.WriteLine("4. Quit");
            Console.Write("Select an activity: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    _activityCounts["Breathing"]++;
                    break;
                case "2":
                    var reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                    _activityCounts["Reflection"]++;
                    break;
                case "3":
                    var listingActivity = new ListingActivity();
                    listingActivity.Run();
                    _activityCounts["Listing"]++;
                    break;
                case "4":
                    Console.WriteLine("Thank you for taking time to be mindful.");
                    return;
                default:
                    Console.WriteLine("That is not a valid option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    WaitForKey();
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to return to the menu...");
            WaitForKey();
        }
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

    private static void WaitForKey()
    {
        try
        {
            if (!Console.IsInputRedirected)
            {
                Console.ReadKey();
            }
        }
        catch (IOException)
        {
        }
    }
}