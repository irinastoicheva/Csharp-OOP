﻿namespace SoftUniRestaurant.Models.Drinks
{
    public class Water : Drink
    {
        private const decimal WaterPrice = 1.5M;

        public Water(string name, int servingSize, string brand)
            : base(name, servingSize, WaterPrice, brand) { }
    }
}
