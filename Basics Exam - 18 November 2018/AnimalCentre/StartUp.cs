namespace AnimalCentre
{
    using System;
    using Core;
    public class StartUp
    {
        public static void Main()
        {
            AnimalCentre animalCentre = new AnimalCentre();
            Engine engine = new Engine(animalCentre);
            engine.Run();
        }
    }
}
