namespace P06.BirthdayCelebrations
{
    public class Robot 
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; }
        public string Id { get;}
    }
}
