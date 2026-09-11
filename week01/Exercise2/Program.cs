using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string inputFromUser = Console.ReadLine();

        double gradePercentage = double.Parse(inputFromUser); 

        double signPart = gradePercentage % 10;
        Console.WriteLine(signPart);
        string sign = "";

        if(signPart >= 7 && gradePercentage < 90)
        {
            sign="+";
        }
        else if (signPart < 3)
        {
            sign="-";
        }
        Console.Write(sign);
       
        if (gradePercentage >= 90)
        {
            Console.WriteLine($"Your grade is: A{sign}");
        }
        else if (gradePercentage >= 80)
        {
            Console.WriteLine($"Your grade is: B{sign}");
        }
        else if (gradePercentage >= 70)
        {
            Console.WriteLine($"Your grade is: C{sign}");
        }
        else if (gradePercentage >= 60)
        {
            Console.WriteLine($"Your grade is: D{sign}");
        }
        else
        {
            Console.WriteLine($"Your grade is: F");
        }

        if (gradePercentage >= 70)
        {
            Console.WriteLine ("Congratulations! You have passed the course ");
        }
        else
        {
            Console.WriteLine("Try better the next time ");
        }
    }
}