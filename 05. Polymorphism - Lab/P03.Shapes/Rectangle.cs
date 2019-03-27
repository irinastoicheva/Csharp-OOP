﻿namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override string Draw()
        {
            return base.Draw() + "Rectangle";
        }

        public override double CalculateArea()
        {
            return this.width * this.height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.width + this.height);
        }
    }
}
