namespace P04.OnlineRadioDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Song> songs = new List<Song>();
            int numberInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInput; i++)
            {
                try
                {
                    string[] songInformation = Console.ReadLine().Split(";");

                    string artistName = songInformation[0];
                    string songName = songInformation[1];
                    string[] durationInfo = songInformation[2].Split(":");
                    bool minutes = int.TryParse(durationInfo[0], out int songMinutes);
                    bool seconds = int.TryParse(durationInfo[1], out int songSeconds);

                    if (!minutes || !seconds)
                    {
                        throw new ArgumentException("Invalid song length.");
                    }

                    Song song = new Song(artistName, songName, songMinutes, songSeconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine($"Songs added: {songs.Count}");
            int durationSecond = songs.Select(x => x.DurationSong()).Sum();
            int[] duration = CalculateDurationList(durationSecond);

            Console.WriteLine($"Playlist length: {duration[0]}h {duration[1]}m {duration[2]}s");
        }

        public static int[] CalculateDurationList(int durationSecond)
        {
            int[] duration = new int[3];

            duration[0] = durationSecond / 60 / 60;
            durationSecond %= 60 * 60;

            duration[1] = durationSecond / 60;

            duration[2] = durationSecond % 60;
            return duration;
        }
    }
}
