namespace P06.Animals
{
    public class Tomcat : Animal
    {
        public Tomcat(string name, int age, string gender = "Male") : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
