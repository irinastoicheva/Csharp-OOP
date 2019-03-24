namespace P05.Mordor_sCruelPlan
{
    public class FoodFactory
    {
        private string[] food;
        public FoodFactory(string[] food)
        {
            this.Food = food;
        }

        public string[] Food { get; set; }

        public int Eat()
        {
            int pointsOfHappiness = 0;

            for (int i = 0; i < this.Food.Length; i++)
            {
                if (this.Food[i].ToLower() == "cram")
                {
                    pointsOfHappiness += 2;
                }
                else if (this.Food[i].ToLower() == "lembas")
                {
                    pointsOfHappiness += 3;
                }
                else if (this.Food[i].ToLower() == "apple" || this.Food[i].ToLower() == "melon")
                {
                    pointsOfHappiness += 1;
                }
                else if (this.Food[i].ToLower() == "honeycake")
                {
                    pointsOfHappiness += 5;
                }
                else if (this.Food[i].ToLower() == "mushrooms")
                {
                    pointsOfHappiness += -10;
                }
                else
                {
                    pointsOfHappiness -= 1;
                }
            }

            return pointsOfHappiness;
        }
    }
}
