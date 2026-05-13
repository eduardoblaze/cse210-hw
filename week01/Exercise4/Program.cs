using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        // 
        int capacity = 10;
        double[] numbers = new double[capacity];
        int count = 0;

        Console.WriteLine("enter a list of numbers, type 0 when you finish.");

        while (true)
        {
            Console.WriteLine("enter number: ");
            string input = Console.ReadLine();
            if (!double.TryParse(input, out double number))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue;
            }

            if (number == 0)
                break;

            if (count == capacity)
            {
                capacity *= 2;
                double[] newArray = new double[capacity];
                for (int i = 0; i < count; i++)
                    newArray[i] = numbers[i];
                numbers = newArray;
            }

            numbers[count] = number;
            count++;
        }

        if (count > 0)
        {
            double sum = 0;
            for (int i = 0; i < count; i++)
                sum += numbers[i];

        
            double average = sum / count;

            double max = numbers[0];
            for (int i = 1; i < count; i++)
                if (numbers[i] > max) max = numbers[i];

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            // Stretch Challenge 1
            double? smallestPositive = null;
            for (int i = 0; i < count; i++)
            {
                if (numbers[i] > 0)
                {
                    if (!smallestPositive.HasValue || numbers[i] < smallestPositive.Value)
                        smallestPositive = numbers[i];
                }
            }

            if (smallestPositive.HasValue)
                Console.WriteLine($"The smallest positive number is: {smallestPositive.Value}");
            else
                Console.WriteLine("The smallest positive number is: (none)");


            double[] sortedNumbers = new double[count];
            for (int i = 0; i < count; i++)
                sortedNumbers[i] = numbers[i];

            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (sortedNumbers[j] > sortedNumbers[j + 1])
                    {
                        double temp = sortedNumbers[j];
                        sortedNumbers[j] = sortedNumbers[j + 1];
                        sortedNumbers[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("The sorteed list is:");
            for (int i = 0; i < count; i++)
                Console.WriteLine(sortedNumbers[i]);
        }
        else
        {
            Console.WriteLine("No numbers were entered Nothing to process.");
        }
    }
}