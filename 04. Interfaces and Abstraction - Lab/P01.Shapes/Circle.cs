﻿namespace Shapes
{
    using System.Text;

    public class Circle : IDrawable
    {
        private int radius;
        public Circle(int radius)
        {
            this.Radius = radius;
        }
        public int Radius { get; private set; }
        public string Draw()
        {
            double rIn = this.Radius - 0.4;
            double rOut = this.Radius + 0.4;
            StringBuilder sb = new StringBuilder();

            for (double y = this.Radius; y >= -this.Radius; y--)
            {
                for (double x = -this.Radius; x < rOut; x += 0.5)
                {
                    double value = x * x + y * y;
                    if (value >= rIn * rIn && value <= rOut * rOut)
                    {
                        sb.Append('*');
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
