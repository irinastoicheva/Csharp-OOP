namespace P05.Mordor_sCruelPlan
{
    public class MoodFactory
    {
        public MoodFactory(int points)
        {
            this.Points = points;
        }
        public int Points { get; private set; }

        public string Mood()
        {
            if (this.Points < - 5)
            {
                return "Angry";
            }
            else if (this.Points >= - 5 && this.Points <= 0)
            {
                return "Sad";
            }
            else if (this.Points >= 0 && this.Points <= 15)
            {
                return "Happy";
            }
            else
            {
                return "JavaScript";
            }
        }
    }
}
