namespace P06_Sneaking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main()
        {
            int numberOfRowRoom = int.Parse(Console.ReadLine());
            Room room = new Room(numberOfRowRoom);

            for (int numberOfRow = 0; numberOfRow < numberOfRowRoom; numberOfRow++)
            {
                char[] row = Console.ReadLine().ToCharArray();
                room.Complete(numberOfRow, row);
            }

            List<int> samCoordinates = room.GetCoordinates('S');
            Position samPosition = new Position(samCoordinates[0], samCoordinates[1]);

            List<int> nicolatzeCoordinates = room.GetCoordinates('N');
            Position nicolatzePosition = new Position(nicolatzeCoordinates[0], nicolatzeCoordinates[1]);

            char[] steps = Console.ReadLine().ToCharArray();

            for (int i = 0; i < steps.Length; i++)
            {
                List<Enemy> enemies = new List<Enemy>();

                List<List<int>> enemiesBCoordinaties = room.GetEnemies('b');
                List<Enemy> enemiesB = GetEnemies(enemiesBCoordinaties, 'b');
                if (enemiesB.Count > 0)
                {
                    enemies.AddRange(enemiesB);
                }

                List<List<int>> enemiesDCoordinaties = room.GetEnemies('d');
                List<Enemy> enemiesD = GetEnemies(enemiesDCoordinaties, 'd');
                if (enemiesD.Count > 0)
                {
                    enemies.AddRange(enemiesD);
                }

                for (int j = 0; j < enemies.Count; j++)
                {
                    Enemy enemy = enemies[j];
                    MoveEnemy(enemy, room);
                }

                List<char> row = room.Values[samPosition.X].ToList();
                bool doesSamContinue = SamDidNotDie(row, samPosition);

                if (!doesSamContinue)
                {
                    Console.WriteLine($"Sam died at {samPosition.X}, {samPosition.Y}");
                    room.Values[samPosition.X][samPosition.Y] = 'X';
                    Console.WriteLine(room);
                    return;
                }

                char destination = steps[i];

                doesSamContinue = MoveSam(samPosition, room, destination);

                if (doesSamContinue && samPosition.X == nicolatzePosition.X)
                {
                    Console.WriteLine("Nikoladze killed!");
                    room.Values[nicolatzePosition.X][nicolatzePosition.Y] = 'X';
                    Console.WriteLine(room);
                    return;
                }
            }
        }

        public static bool MoveSam(Position samPosition, Room room, char destination)
        {
            room.Values[samPosition.X][samPosition.Y] = '.';
            List<char> row;
            bool samDidNotDie = false;

            switch (destination)
            {
                case 'U':
                    samPosition.X--;
                    row = room.Values[samPosition.X].ToList();
                    samDidNotDie = SamDidNotDie(row, samPosition);
                    break;

                case 'D':
                    samPosition.X++;
                    row = room.Values[samPosition.X].ToList();
                    samDidNotDie = SamDidNotDie(row, samPosition);
                    break;

                case 'L':
                    samPosition.Y--;
                    row = room.Values[samPosition.X].ToList();
                    samDidNotDie = SamDidNotDie(row, samPosition);
                    break;

                case 'R':
                    samPosition.Y++;
                    row = room.Values[samPosition.X].ToList();
                    samDidNotDie = SamDidNotDie(row, samPosition);
                    break;
                case 'W':
                    break;
            }

            if (samDidNotDie)
            {
                room.Values[samPosition.X][samPosition.Y] = 'S';
            }
            else
            {
                room.Values[samPosition.X][samPosition.Y] = 'X';
            }
            return samDidNotDie;
        }

        public static bool SamDidNotDie(List<char> row, Position samPosition)
        {
            if (row.Contains('b'))
            {
                int colB = row.IndexOf('b');
                if (samPosition.Y > colB)
                {
                    return false;
                }
            }
            else if (row.Contains('d'))
            {
                int colD = row.IndexOf('d');
                if (samPosition.Y < colD)
                {
                    return false;
                }
            }

            return true;
        }

        public static List<Enemy> GetEnemies(List<List<int>> coordinaties, char name)
        {
            List<Enemy> enemies = new List<Enemy>();
            for (int i = 0; i < coordinaties.Count; i++)
            {
                Position position = new Position(coordinaties[i][0], coordinaties[i][1]);
                Enemy enemy = new Enemy(name, position);
                enemies.Add(enemy);
            }

            return enemies;
        }

        public static void MoveEnemy(Enemy enemy, Room room)
        {
            room.Values[enemy.Position.X][enemy.Position.Y] = '.';
            if (enemy.Name == 'b')
            {
                int lengthOfRowOfRoom = room.Values[enemy.Position.X].Length;
                if (enemy.Position.Y == lengthOfRowOfRoom - 1)
                {
                    enemy.Name = 'd';
                    room.Values[enemy.Position.X][enemy.Position.Y] = 'd';
                }
                else
                {
                    enemy.Position.Y++;
                    room.Values[enemy.Position.X][enemy.Position.Y] = 'b';
                }
            }
            else
            {
                if (enemy.Position.Y == 0)
                {
                    enemy.Name = 'b';
                    room.Values[enemy.Position.X][enemy.Position.Y] = 'b';
                }
                else
                {
                    enemy.Position.Y--;
                    room.Values[enemy.Position.X][enemy.Position.Y] = 'd';
                }
            }
        }
    }
}
