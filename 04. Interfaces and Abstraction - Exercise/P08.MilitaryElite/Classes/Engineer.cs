using System.Collections.Generic;
using System.Text;

namespace P08.MilitaryElite
{
    public class Engineer : Private, IEngineer
    {


        public Engineer(int id, string firstName, string lastName, decimal salary, string corps, HashSet<Repair> repairs)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
            this.Repairs = repairs;
        }
        public HashSet<Repair> Repairs { get; private set; }

        public string Corps { get; private set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");
            foreach (var item in this.Repairs)
            {
                sb.AppendLine($"  {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}