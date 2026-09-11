using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        Console.Write("Enter Number: ");
        string inputFromUser = Console.ReadLine();
        int numberToAdd = int.Parse(inputFromUser);

        while (numberToAdd != 0)
        {
            numbers.Add(numberToAdd);
            Console.Write("Enter Number: ");
            inputFromUser = Console.ReadLine();
            numberToAdd = int.Parse(inputFromUser);
            numbers.ForEach(Console.WriteLine);

        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number; 
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {(float)sum/numbers.Count}");
        Console.WriteLine($"The largest number is: {numbers.Max()}");


    }
}