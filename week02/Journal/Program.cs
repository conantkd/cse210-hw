// I made this by myself by adding a feeling score from 1 to 10 to each journal entry.
using System;

class Program
{
    static void displayMenu()
    {
        Console.WriteLine("Please Select one option by Typing the number");
        Console.WriteLine("1. Write a new Entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Quit");
    }
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();
        string filename;
        string answer;
        string inputFromUser;

        Console.WriteLine("========Hello Welcome to the Journal App========");
        displayMenu();
        inputFromUser = Console.ReadLine();

        while (inputFromUser != "5" && inputFromUser != "Quit")
        {
            if (inputFromUser == "1")
            {
                Entry entry = new Entry();
                entry._promptText = promptGenerator.GetRandomPrompt();
                Console.WriteLine(entry._promptText);
                answer = Console.ReadLine();
                entry._entryText = answer;
                Console.WriteLine("From 1 to 10 how do you felt today:");
                answer = Console.ReadLine();
                entry._feelingText = answer;
                DateTime theCurrentTime = DateTime.Now;
                entry._date = theCurrentTime.ToShortDateString();
                journal.AddEntry(entry);

                displayMenu();
            }
            else if (inputFromUser == "2")
            {
                journal.DisplayAll();
                displayMenu();
            }
            else if (inputFromUser == "3")
            {
                Console.Write("Type the name of the file without extension (it will be save as a .csv) then press Enter: ");
                filename = Console.ReadLine();
                journal.SaveToFile(filename);
                Console.WriteLine("Save successfully");
                displayMenu();
            }
            else if (inputFromUser == "4")
            {
                Console.Write("You will overwrite the current Journal entries, are you sure to proceed? Y/N: ");
                inputFromUser = Console.ReadLine();
                if (inputFromUser == "Y" || inputFromUser == "y")
                {   
                    Console.Write("Type the name of the file without extension (it will be load the .csv) then press Enter: ");
                    filename = Console.ReadLine();
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Load successfully");
                }

                displayMenu();
            }
            inputFromUser = Console.ReadLine();
        }
    }
}