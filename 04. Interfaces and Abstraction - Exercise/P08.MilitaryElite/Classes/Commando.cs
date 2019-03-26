namespace P08.MilitaryElite
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Commando : Private, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, string corps, HashSet<Mission> missions)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
            this.Missions = missions;
        }
        public string Corps { get; private set; }

        public HashSet<Mission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.Append("Missions:");
            foreach (var item in this.Missions)
            {
                sb.Append($"{item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}