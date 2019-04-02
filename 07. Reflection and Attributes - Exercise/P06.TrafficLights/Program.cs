namespace P06.TrafficLights
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split();

            List<TrafficLight> trafficLights = new List<TrafficLight>();

            for (int i = 0; i < input.Length; i++)
            {
                TrafficLight trafficLight = new TrafficLight((Color)Enum.Parse(typeof(Color), input[1]));
                trafficLights.Add(trafficLight);
            }

            int numberChangeTratticLights = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberChangeTratticLights; i++)
            {
                foreach (TrafficLight item in trafficLights)
                {
                    item.ChangesColor();
                    Console.Write((item.Color) + " ");
                }

                Console.WriteLine();
                //Color)Enum.Parse(typeof(Color), input[i])
            }
        }
    }
}
