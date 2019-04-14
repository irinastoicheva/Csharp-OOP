using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities.Models
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        //private List<string> targets;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.pilot = null;
            this.Targets = new List<string>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }

        public double AttackPoints { get; protected set; }
        public double DefensePoints { get; protected set; }
        public double HealthPoints { get; set; }
        public IList<string> Targets { get; set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            target.HealthPoints -= (this.AttackPoints - target.DefensePoints);
            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");

            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints}");
            sb.AppendLine($" *Attack: {this.AttackPoints}");
            sb.AppendLine($" *Defense: {this.DefensePoints}");
            sb.Append(" *Targets: ");
            if (this.Targets.Count == 0)
            {
                sb.AppendLine("None");
            }
            else
            {
                sb.AppendLine($"{string.Join(", ", this.Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
