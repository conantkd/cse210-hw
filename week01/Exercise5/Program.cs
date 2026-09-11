using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squareNumber = SquareNumber(userNumber);

        DisplayResult(userName, squareNumber);

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            return userName;

        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string inputFromUser = Console.ReadLine();
            int userNumber = int.Parse(inputFromUser);
            return userNumber;
            
        }

        static int SquareNumber(int userNumber)
        {
            return userNumber * userNumber;
        }
        
        static void DisplayResult(string userName, int squareNumber)
        {
            Console.WriteLine($"{userName}, the square of your number is: {squareNumber}");
        }




     
        

    }
}