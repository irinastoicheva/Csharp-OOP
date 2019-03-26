namespace P08.MilitaryElite
{
    public class Repair
    {
        public Repair(string name, int workedHours)
        {
            this.Name = name;
            this.WorkedHours = workedHours;
        }

        public int WorkedHours { get; set; }
        public string Name { get; set; }


        public override string ToString()
        {
            return $"Part Name: {this.Name} Hours Worked: {this.WorkedHours}";
        }
    }
}