namespace P08.MilitaryElite
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            Army army = new Army();

            while (input != "End")
            {
                string[] parts = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string typeSoldier = parts[0];
                int id = int.Parse(parts[1]);
                string firstName = parts[2];
                string lastName = parts[3];
                decimal salary;
                string corps;

                switch (typeSoldier)
                {

                    case "Private":
                        salary = decimal.Parse(parts[4]);
                        Private currentPrivate = new Private(id, firstName, lastName, salary);
                        army.AddSoldier(currentPrivate);
                        break;

                    case "LieutenantGeneral":
                        salary = decimal.Parse(parts[4]);
                        int[] ids = new int[parts.Length - 5];
                        for (int i = 0; i < ids.Length; i++)
                        {
                            ids[i] = int.Parse(parts[i + 5]);
                        }

                        HashSet<Private> privates = army.GetPrivates(ids);
                        LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                        army.AddSoldier(lieutenantGeneral);
                        break;

                    case "Engineer":
                        salary = decimal.Parse(parts[4]);
                        corps = parts[5];
                        if (corps == "Marines" || corps == "Airforces")
                        {
                            HashSet<Repair> repairs = new HashSet<Repair>();
                            for (int i = 6; i < parts.Length; i += 2)
                            {
                                Repair repair = new Repair(parts[i], int.Parse(parts[i + 1]));
                                if (repair != null)
                                {
                                    repairs.Add(repair);
                                }
                            }

                            Engineer engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);

                            army.AddSoldier(engineer);
                        }
                        break;
                    case "Commando":
                        salary = decimal.Parse(parts[4]);
                        corps = parts[5];
                        if (corps == "Marines" || corps == "Airforces")
                        {
                            HashSet<Mission> missions = new HashSet<Mission>();
                            for (int i = 6; i < parts.Length; i += 2)
                            {
                                Mission mission = new Mission(parts[i], parts[i + 1]);
                                if (mission != null)
                                {
                                    missions.Add(mission);
                                }
                            }

                            Commando commando = new Commando(id, firstName, lastName, salary, corps, missions);
                            army.AddSoldier(commando);
                        }
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(parts[4]);
                        Spy spy = new Spy(id, firstName, lastName, codeNumber);
                        army.AddSoldier(spy);
                        break;
                }

                input = Console.ReadLine();

            }

            Console.WriteLine(army);
        }
    }
}