﻿namespace P02.ClassBoxDataValidation
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(length, width, height);
                Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.CalculateVolume():F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
