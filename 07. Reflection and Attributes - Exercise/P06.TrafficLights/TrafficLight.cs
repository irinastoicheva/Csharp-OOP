using System;
using System.Linq;

namespace P06.TrafficLights
{
    public class TrafficLight
    {
        public TrafficLight(Color color)
        {
            this.Color = color;
        }
        public Color Color { get; set; }

        public void ChangesColor()
        {
            Color nextValue = this.Color;

            if (this.Color == Enum.GetValues(typeof(Color)).Cast<Color>().Last())
            {
                nextValue = 0;
            }
            else
            {
                nextValue = Enum.GetValues(typeof(Color)).Cast<Color>().SkipWhile(e => e != this.Color).Skip(1).First();
            }

            this.Color = nextValue;
        }
    }
}
