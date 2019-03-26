namespace P07.FoodShortage
{
    public class Human : IBuyer
    {
        public Human(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Id { get; }
        public string Birthdate { get; private set; }

        public int Food { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
