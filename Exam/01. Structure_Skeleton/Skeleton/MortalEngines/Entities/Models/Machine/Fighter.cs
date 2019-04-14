using MortalEngines.Entities.Contracts;
using System.Text;

namespace MortalEngines.Entities.Models.Machine
{
   public class Fighter : BaseMachine, IFighter
    {
        private const double initialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, initialHealthPoints)
        {
            this.AggressiveMode = true;
        }

        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            if (this.AggressiveMode)
            {
                this.AggressiveMode = false;
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
            else
            {
                this.AggressiveMode = true;
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.Append(" *Aggressive: ");
            if (this.AggressiveMode == true)
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
