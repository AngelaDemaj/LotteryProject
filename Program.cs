using System;
using System.Collections.Generic;
using System.Linq;

namespace LotteryProject
{
    class Program
    {
        public static HashSet<int> GenerateNumbers(int numbersCount)
        {
            var numbers = new HashSet<int>();

            var random = new Random();

            while (numbers.Count < numbersCount)
            {
                numbers.Add(random.Next(1, 81));
            }

            return numbers;
        }

        public static int ValidateInt(int lowerBound, int upperBound, string input)
        {
            var isInt = int.TryParse(input, out var choice);

            if (isInt && choice >= lowerBound && choice <= upperBound)
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Incorrect Number, enter a correct number");
                while (!int.TryParse(Console.ReadLine(), out choice) ||
                    choice < lowerBound ||
                    choice > upperBound)
                {
                    Console.WriteLine("Incorrect Number, enter a correct number");
                }
            }
            return choice;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Choose the amount of numbers you want to pick:");
            var userInput = ValidateInt(1, 12, Console.ReadLine());

            var userNumbers = new HashSet<int>();

            while (userNumbers.Count < userInput)
            {
                Console.WriteLine("Enter a number!");
                var userNumber = ValidateInt(1, 80, Console.ReadLine());

                userNumbers.Add(userNumber);
            }

            var drawNumbers = GenerateNumbers(20);

            var elementsFound = userNumbers.Intersect(drawNumbers).ToHashSet();

            Console.WriteLine($"You found {elementsFound.Count} number/s");
        }
    }
}
