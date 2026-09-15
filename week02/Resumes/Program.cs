using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Google";
        job1._startYear = 2026;
        job1._endYear = 2028;
        job1.Display();

        Job job2 = new Job();
        job2._jobTitle = "Analyst";
        job2._company = "Google";
        job2._startYear = 2028;
        job2._endYear = 2040;
        job2.Display();

        Resume myResume = new Resume();
        myResume._name ="Luis Chaves";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
}