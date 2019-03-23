namespace P02.PoinInRectangle
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] coordinatesRectangle = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int x1 = coordinatesRectangle[0];
            int y1 = coordinatesRectangle[1];
            int x2 = coordinatesRectangle[2];
            int y2 = coordinatesRectangle[3];

            Point topLeft = new Point(x1, y1);
            Point bottobRight = new Point(x2, y2);

            Rectangle rectangle = new Rectangle(topLeft, bottobRight);

            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                int[] coordinatesPoint = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                Point point = new Point(coordinatesPoint[0], coordinatesPoint[1]);
                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
