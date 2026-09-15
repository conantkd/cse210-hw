public class Journal
{
    List<Entry> _entries = new List<Entry>();

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        ;
    }
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines($"{filename}.csv");

        foreach (string line in lines)
        {
            string[] parts = line.Split(";");
            Entry entry = new Entry();

            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];
            entry._feelingText = parts[3];
            AddEntry(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter($"{filename}.csv"))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(
                    $"{entry._date};{entry._promptText};{entry._entryText};{entry._feelingText}");
            }
        }
    }
}

