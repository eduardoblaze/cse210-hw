using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = journal.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    // creativity: get mood user
                    int mood = 0;
                    while (mood < 1 || mood > 5)
                    {
                        Console.Write("Rate your mood (1-5, 5 is best): ");
                        string moodInput = Console.ReadLine();
                        int.TryParse(moodInput, out mood);
                        if (mood < 1 || mood > 5)
                            Console.WriteLine("Please enter a number between 1 and 5.");
                    }

                    string date = DateTime.Now.ToString("yyyy-MM-dd");
                    Entry newEntry = new Entry();
                    newEntry._date = date;
                    newEntry._prompt = prompt;
                    newEntry._response = response;
                    newEntry._mood = mood;
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry added.\n");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.\n");
                    break;
            }
        }
    }
}