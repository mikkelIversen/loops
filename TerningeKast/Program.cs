using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Serialization.Configuration;

namespace TerningeKast
{
    internal class Program
    {
        static long counter = 0;
        static volatile bool rolledCorrect = false;
        
        public static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            long diceAmount;
            int diceSides;

            int workerThreadCount;
            try
            {
                Console.WriteLine("Please enter the number of worker threads you want to run");
                workerThreadCount = int.Parse(System.Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("You entered an invalid number");
                Start();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("Sounds/Error.wav");
                return;
            }
            
            try
            {
                Console.WriteLine("Please enter the number of dice's you want to roll");
                diceAmount = long.Parse(System.Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("You entered an invalid number");
                Start();
                return;
            }
            
            try
            {
                Console.WriteLine("Please enter the number of sides your dice's should have");
                diceSides = int.Parse(System.Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("You entered an invalid number");
                Start();
                return;
            }
            
            int workers = Environment.ProcessorCount;
            Thread[] threads = new Thread[workerThreadCount];
            
            for (int i = 0; i < workerThreadCount; i++)
            {
                threads[i] = new Thread(() =>
                {
                    Dice dice = new Dice(diceSides);
                    while (!rolledCorrect)
                    {
                        if (TryRoll(diceAmount, dice))
                        {
                            rolledCorrect = true;
                        }

                        Interlocked.Increment(ref counter);
                    }
                });

                threads[i].IsBackground = true;
                threads[i].Start();
            }

            foreach (var t in threads)
                t.Join();
            
            System.Console.WriteLine("You threw " + diceAmount + " dice's " + counter + " times before you got all 6");
        }

        public static bool TryRoll(long amount, Dice dice)
        {
            for (long i = 0; i < amount; i++)
            {
                if (dice.roll() + 1 != 6) return false;
            }
            return true;
        }
    }
}