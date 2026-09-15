public class PromptGenerator
{
    List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What did I accomplish today?",
        "What challenge did I overcome today?",
        "What did I learn about myself today?",
        "What is one thing I am looking forward to tomorrow?"
    };
     Random random = new Random();

     public string GetRandomPrompt()
    {
        int i = random.Next(_prompts.Count);
        return _prompts[i];
    }
}