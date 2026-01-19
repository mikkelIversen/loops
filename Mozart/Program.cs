using System;
using System.IO;
using System.Media;

namespace Mozart
{
    internal class Program
    {
        private static readonly string folderPath =
            @"C:\Users\mikkel\RiderProjects\Loops\Mozart\piano";

        static readonly SoundPlayer soundPlayer = new SoundPlayer();
        static readonly Random random = new Random();
        
        public static void Main(string[] args)
        {
            PlayMinuet();
            PlayTrio();
        }

        static void PlayMinuet()
        {
            for (int i = 0; i < 16; i++)
            {
                int num1 = random.Next(1, 7);
                int num2 = random.Next(1, 7);

                string fileName = $"minuet{i}-{num1 + num2}.wav";
                string fullPath = Path.Combine(folderPath, fileName);
                
                Console.WriteLine(fileName);
                soundPlayer.SoundLocation = fullPath;
                soundPlayer.Load();
                soundPlayer.PlaySync();
            }
        }
        static void PlayTrio()
        {
            for (int i = 0; i < 16; i++)
            {
                int num = random.Next(1, 7);

                string fileName = $"trio{i}-{num}.wav";
                string fullPath = Path.Combine(folderPath, fileName);
                
                Console.WriteLine(fileName);
                soundPlayer.SoundLocation = fullPath;
                soundPlayer.Load();
                soundPlayer.PlaySync();
            }
        }
    }
}