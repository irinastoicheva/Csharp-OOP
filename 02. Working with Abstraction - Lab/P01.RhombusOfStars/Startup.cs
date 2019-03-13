namespace _01.RhombusOfStars
{
    using System;
    public class Startup
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            PrintToUpper(number);
            PrintToLower(number);
        }

        public static void Print(int number, int i)
        {
            string whiteSpace = new string(' ', number - i);
            Console.Write(whiteSpace);
            for (int j = 0; j < i; j++)
            {
                Console.Write("* ");
            }

            Console.WriteLine(whiteSpace);
        }

        public static void PrintToUpper(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                Print(number, i);
            }
        }

        public static void PrintToLower(int number)
        {
            for (int i = number - 1; i > 0; i--)
            {
                Print(number, i);
            }
        }
    }
}

