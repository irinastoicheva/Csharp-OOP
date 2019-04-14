namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
                return $"Tank {name} manufactured - attack: {attackPoints}; defense: {defensePoints}";
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
                var instance = (IMachine)Activator.CreateInstance(classType, new object[] { name, attackPoints, defensePoints });
                this.machines.Add(instance);
                return $"Fighter {name} manufactured - attack: {attackPoints}; defense: {defensePoints}; aggressive: ON";
            }
            else
            {
                return $"Machine {name} is manufactured already";
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            throw new System.NotImplementedException();
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            throw new System.NotImplementedException();
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