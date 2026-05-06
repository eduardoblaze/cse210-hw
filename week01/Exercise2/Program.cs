using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter your grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());

        string letter = "";   //  A, B, C, D, F
        string sign = "";     // +, -

        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }


        if (letter != "F")
        {
            int lastDigit = percentage % 10;

            if (lastDigit >= 7)
            {
                // For A no + sign
                if (letter != "A")
                {
                    sign = "+";
                }
            }
            else if (lastDigit <= 2)
            {
                sign = "-";
            }
        }
        // F neve gets a sign

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up! Better luck next time.");
        }
    }
}
