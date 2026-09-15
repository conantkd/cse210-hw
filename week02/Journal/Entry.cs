public class Entry
{
    public string _entryText;
    public string _feelingText;
    public string _date;
    public string _promptText;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine($"From 1 to 10 I felt: {_feelingText}");
        Console.WriteLine();
    }


}