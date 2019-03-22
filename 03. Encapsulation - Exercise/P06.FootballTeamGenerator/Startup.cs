namespace P06.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] inputLine = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                if (inputLine.Length == 2)
                {
                    if (inputLine[0] == "Team")
                    {
                        try
                        {
                            string name = inputLine[1];
                            Team team = new Team(name);
                            teams.Add(team);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else if (inputLine[0] == "Rating")
                    {
                        string name = inputLine[1];
                        if (teams.Any(x => x.Name == name))
                        {
                            Team team = teams.FirstOrDefault(x => x.Name == name);
                            Console.WriteLine($"{team.Name} - {team.Rating()}");
                        }
                        else
                        {
                            throw new ArgumentException($"Team {name} does not exist.");
                        }
                    }
                }
                else if (inputLine.Length == 3 && inputLine[0] == "Remove")
                {
                    string teamName = inputLine[1];
                    if (teams.Any(x => x.Name == teamName))
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == teamName);
                        try
                        {
                            string playerName = inputLine[2];
                            team.RemovePlayer(playerName);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                }
                else if (inputLine.Length == 8 && inputLine[0] == "Add")
                {
                    string teamName = inputLine[1];
                    string playerName = inputLine[2];
                    int endurance = int.Parse(inputLine[3]);
                    int sprint = int.Parse(inputLine[4]);
                    int dribble = int.Parse(inputLine[5]);
                    int passing = int.Parse(inputLine[6]);
                    int shooting = int.Parse(inputLine[7]);

                    if (teams.Any(x => x.Name == teamName))
                    {
                        try
                        {
                            Team team = teams.FirstOrDefault(x => x.Name == teamName);

                            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                            team.AddPlayer(player);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
