using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05OnlineRadioDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Song> playlist = new List<Song>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] input = Console.ReadLine().Split(';');
                    string author = input[0];
                    string songName = input[1];
                    int[] lenght = input[2].Split(':').Select(int.Parse).ToArray();
                    int minutes = lenght[0];
                    int seconds = lenght[1];
                    Song song = new Song(author, songName, minutes, seconds);
                    playlist.Add(song);
                    Console.WriteLine("Song added.");
                }

                catch (InvalidSongException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException fex)
                {
                    Console.WriteLine("Invalid song length.");
                }
            }

            Console.WriteLine($"Songs added: {playlist.Count}");
            int totalMinutes = playlist.Sum(x => x.Minutes);
            int totalSeconds = playlist.Sum(x => x.Seconds);

            totalSeconds += totalMinutes * 60;

            int finalMinutes = totalSeconds / 60;
            int finalSeconds = totalSeconds % 60;
            int finalHours = finalMinutes / 60;
            finalMinutes %= 60;
            Console.WriteLine($"Playlist length: {finalHours}h {finalMinutes}m {finalSeconds}s");
        }
    }
}
