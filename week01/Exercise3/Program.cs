using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,101);
        
        Console.WriteLine("Welcome to the Magic Number game!");

        //Console.Write("What is the magic number?: ");//
        //string inputFromUser = Console.ReadLine();//
        //int magicNumber = int.Parse(inputFromUser);//
        
        Console.Write("What is your guess: ");
        string inputFromUser = Console.ReadLine();
        int guessNumber = int.Parse(inputFromUser);

        while (magicNumber != guessNumber)
        {
            if (magicNumber > guessNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guessNumber)
            {
                Console.WriteLine("Lower");
            }

            Console.Write("What is your guess?: ");
            inputFromUser = Console.ReadLine();
            guessNumber = int.Parse(inputFromUser);

        }

        Console.WriteLine("You guessed it!");

    }
}