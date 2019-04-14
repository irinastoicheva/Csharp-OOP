using MortalEngines.Entities.Contracts;
using System.Text;

namespace MortalEngines.Entities.Models.Machine
{
    public class Tank : BaseMachine, ITank
    {
        private const double initialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints - 40, defensePoints + 30, initialHealthPoints)
        {
            this.DefenseMode = true;
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
            else
            {
                this.DefenseMode = true;
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append(" *Defense: ");
            if (this.DefenseMode == true)
            {
                sb.AppendLine("ON");
            }
            else
            {
                sb.AppendLine("OFF");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
