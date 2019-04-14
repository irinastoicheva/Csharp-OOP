namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities.Contracts;
    using MortalEngines.Entities.Models.Machine;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MachinesManager : IMachinesManager
    {
        private List<IPilot> pilots;
        private List<IMachine> machines;
        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            string result = string.Empty;
            if (this.pilots.Any(x => x.Name == name))
            {
                result = $"Pilot {name} is hired already";
            }
            else
            {
                result = $"Pilot {name} hired";

                var classType = typeof(MachinesManager).Assembly.GetTypes().FirstOrDefault(x => x.Name == "Pilot");
                var instance = (IPilot)Activator.CreateInstance(classType, new object[] {name});

                this.pilots.Add(instance);
            }

            return result;
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            IMachine machine = this.machines.FirstOrDefault(x => x.Name == name && x.AttackPoints == attackPoints && x.DefensePoints == defensePoints);
            if (machine == null)
            {
                var classType = typeof(MachinesManager).Assembly.GetTypes().FirstOrDefault(x => x.Name == "Tank");
                var instance = (IMachine)Activator.CreateInstance(classType, new object[] {name, attackPoints, defensePoints});
                this.machines.Add(instance);
                return $"Tank {name} manufactured - attack: {instance.AttackPoints:F2}; defense: {instance.DefensePoints:F2}";
            }
            else
            {
                return $"Machine {name} is manufactured already";
            }

        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            IFighter fighter = (IFighter)this.machines.FirstOrDefault(x => x.Name == name && x is IFighter);
            if (fighter == null)
            {
                var classType = typeof(MachinesManager).Assembly.GetTypes().FirstOrDefault(x => x.Name == "Fighter");
                var instance = (Fighter)Activator.CreateInstance(classType, new object[] { name, attackPoints, defensePoints });
                this.machines.Add(instance);
                return $"Fighter {name} manufactured - attack: {instance.AttackPoints:F2}; defense: {instance.DefensePoints:F2}; aggressive: ON";
            }
            else
            {
                return $"Machine {name} is manufactured already";
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IMachine machine = this.machines.FirstOrDefault(x => x.Name == selectedMachineName && x.Pilot == null);
            string result = string.Empty;

            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            if (pilot == null)
            {
                result = $"Pilot {selectedPilotName} could not be found";
            }
            else if (machine == null)
            {
                result = $"Machine {selectedMachineName} could not be found";
            }
            else if (machine.Pilot != null)
            {
                result = $"Machine {selectedMachineName} is already occupied";
            }
            else
            {
                machine.Pilot = pilot;
                pilot.AddMachine(machine);
                result = $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
            }

            return result;
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            IMachine attackingMachine = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);
            IMachine defendingMachine = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);

            string result = string.Empty;
            if (attackingMachine == null)
            {
                result = $"Machine {attackingMachineName} could not be found";
            }
            else if (defendingMachine == null)
            {
                result = $"Machine {defendingMachineName} could not be found";
            }
            else if(attackingMachine.HealthPoints <= 0)
            {
                result = $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }
            else if (defendingMachine.HealthPoints <= 0)
            {
                result = $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }
            else
            {
                attackingMachine.Attack(defendingMachine);
                result = $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints}";
            }

            return result;
        }

        public string PilotReport(string pilotReporting)
        {
            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == pilotReporting);
            if (pilot != null)
            {
                return $"{pilot.Report()}";
            }
            else
            {
                return $"Pilot {pilotReporting} could not be found";
            }
        }

        public string MachineReport(string machineName)
        {
            IMachine machine = this.machines.FirstOrDefault(x => x.Name == machineName);
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            IFighter machine = (IFighter)this.machines.FirstOrDefault(x => x.Name == fighterName && x is IFighter);
            if (machine == null)
            {
                return $"Machine {fighterName} could not be found";
            }
            else
            {
                machine.ToggleAggressiveMode();
                return $"Fighter {fighterName} toggled aggressive mode";
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            ITank machine = (ITank)this.machines.FirstOrDefault(x => x.Name == tankName && x is ITank);
            if (machine == null)
            {
                return $"Machine {tankName} could not be found";
            }
            else
            {
                machine.ToggleDefenseMode();
                return $"Tank {tankName} toggled defense mode";
            }
        }
    }
}