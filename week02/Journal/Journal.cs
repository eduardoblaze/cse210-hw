using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public List<Entry> _entries = new List<Entry>();
    private static string[] _prompts = new string[]
    {
        "Who made me laugh today",
        "What was the hardest thing I did today",
        "How did I help someone today",
        "What am I grateful for right now",
        "What did I eat that was really good",
        "Where did I go today",
        "What was something new I tried today"
    };
    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Length);
        return _prompts[index];
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.\n");
            return;
        }
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry e in _entries)
            {
                // save mood as well: date~|~prompt~|~response~|~mood
                writer.WriteLine($"{e._date}~|~{e._prompt}~|~{e._response}~|~{e._mood}");
            }
        }
        Console.WriteLine("Journal saved.\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }
        List<Entry> loadedEntries = new List<Entry>();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
            if (parts.Length == 4) // now 4 parts including mood
            {
                Entry e = new Entry();
                e._date = parts[0];
                e._prompt = parts[1];
                e._response = parts[2];
                int.TryParse(parts[3], out e._mood);
                loadedEntries.Add(e);
            }
        }
        _entries = loadedEntries;
        Console.WriteLine("Journal loaded.\n");
    }
}