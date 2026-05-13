using System;

class Entry
{
    public string _prompt;
    public string _response;
    public string _date;
    public int _mood; // creativity: 1-5 mood rating

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Mood: {_mood}/5");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }
}