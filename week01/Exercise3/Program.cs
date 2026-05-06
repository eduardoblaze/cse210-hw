using System;

class Program
{
    static void Main()
    {
        int guessCount = 0;

        Random random = new Random();
        int magicNumber = random.Next(1, 101); // 1 to 1'00 inclusive

        int guess = 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // (stretch challenge)
            guessCount++;

            if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }

        Console.WriteLine($"It took you {guessCount} guess(es).");
    }
}