namespace SoftUniRestaurant
{
    using Core;
    using System;
    public class StartUp
    {
        public static void Main()
        {
            RestaurantController rc = new RestaurantController();
            Engine engine = new Engine(rc);
            engine.Run();
        }
    }
}
