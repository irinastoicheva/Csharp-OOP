namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] sizeMatrix = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Matrix matrix = new Matrix(sizeMatrix[0], sizeMatrix[1]);
            matrix.FillIn();

            string command = Console.ReadLine();
            long points = 0;
            while (command != "Let the Force be with you")
            {
                int[] coordinatesIvoStart = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] coordinatesEvil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                AvailableStars changingMatrix = new AvailableStars(coordinatesEvil[0], coordinatesEvil[1]);
                Matrix currentMatrix = changingMatrix.Change(matrix);
                CalculatorForPoints calculatorForIvoPoints = new CalculatorForPoints(coordinatesIvoStart[0], coordinatesIvoStart[1]);
                points += calculatorForIvoPoints.Calculate(currentMatrix);

                command = Console.ReadLine();
            }

            Console.WriteLine(points);
        }
    }
}
