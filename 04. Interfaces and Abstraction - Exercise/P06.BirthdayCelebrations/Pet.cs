namespace P06.BirthdayCelebrations
{
    public class Pet : IIdentificator
    {
        private string name;
        public Pet(string name, string birthdate)
        {
            this.name = name;
            this.Birthdate = birthdate;
        }
        
        public string Birthdate { get; private set; }
    }
}
