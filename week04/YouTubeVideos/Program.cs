using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video("The Best Homemade Pizza", "Cooking with Mia", 642),
            new Video("Beginner's Guide to Hiking", "Trail Notes", 815),
            new Video("Build a Simple Desk", "Weekend Workshop", 1094),
            new Video("Five-Minute Morning Stretch", "Move Every Day", 356)
        };

        videos[0].AddComment(new Comment("Jordan Lee", "The crust came out perfectly!"));
        videos[0].AddComment(new Comment("Avery Chen", "Great instructions, thanks for sharing."));
        videos[0].AddComment(new Comment("Sam Rivera", "I added mushrooms and it was delicious."));

        videos[1].AddComment(new Comment("Taylor Morgan", "This helped me plan my first hike."));
        videos[1].AddComment(new Comment("Casey Patel", "The packing tips were especially useful."));
        videos[1].AddComment(new Comment("Riley Brooks", "Which trail would you recommend next?"));

        videos[2].AddComment(new Comment("Jamie Kim", "The finished desk looks great."));
        videos[2].AddComment(new Comment("Morgan Diaz", "I used reclaimed wood for mine."));
        videos[2].AddComment(new Comment("Alex Johnson", "Clear steps and a very helpful video."));

        videos[3].AddComment(new Comment("Drew Wilson", "A nice way to start the morning."));
        videos[3].AddComment(new Comment("Reese Clark", "That shoulder stretch feels amazing."));
        videos[3].AddComment(new Comment("Cameron Park", "Short and easy to fit into my day."));

        foreach (Video video in videos)
        {
            video.Display();
            Console.WriteLine();
        }
    }
}