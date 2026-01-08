using System;
using System.Collections.Generic;
using System.Linq;

namespace Loops
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WriteTable();
            PrintBiggestnumber([10, 24, 1, 40]);

            Two7sNextToEachother([8, 2, 5, 7, 9, 0, 7, 7, 7, 3, 1]);
            ThreeIncreasingAdjacent([45, 23, 44, 68, 65, 70, 80, 81, 82]);
            SieveOfEratosthenes(30);
            ExtractString();
            FullSequenceOfLetters();
            SumAndAverage(-10, 0);
            DrawTriangle();
            ToThePowerOf(5, 5);
        }

        public static void WriteTable()
        {
            int gridSize = 10;
            for (int row = 1; row < gridSize + 1; row++)
            {
                for (int col = 1; col < gridSize + 1; col++)
                {
                    Console.Write(col * row + ", ");
                }
                Console.WriteLine();
            }
        }

        public static void Two7sNextToEachother(int[] nums)
        {
            int numToFind = 7;

            int highestTimesFound = 0;
            int timesFound = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == numToFind)
                {
                    timesFound++;
                    if (timesFound > highestTimesFound)
                    {
                        highestTimesFound = timesFound;
                    }
                }
                else
                {
                    timesFound = 0;
                }
            }
            
            Console.WriteLine($"Found {highestTimesFound} sevens beside each other");
        }
        
        public static void ThreeIncreasingAdjacent(int[] nums)
        {
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i+1] == nums[i] + 1 && nums[i +2] == nums[i+1] +1)
                {
                    Console.Write("Found three increasing adjacent");
                }
            }
        }

        public static void PrintBiggestnumber(int[] nums)
        {
            Array.Sort(nums);
            Console.WriteLine(nums[nums.Length - 1]);
        }

        public static void SieveOfEratosthenes(int num)
        {
            // Boolean array to mark primes
            bool[] prime = new bool[num + 1];
            for (int i = 0; i <= num; i++) {
                prime[i] = true;
            }

            // Sieve of Eratosthenes
            for (int p = 2; p * p <= num; p++)
            {
                if (prime[p])
                {
                    for (int i = p * p; i <= num; i += p)
                    {
                        prime[i] = false;
                    }
                }
            }

            // Store primes in list
            List<int> res = new List<int>();
            for (int i = 2; i <= num; i++)
            {
                if (prime[i])
                {
                    res.Add(i);
                }
            }

            
            Console.WriteLine($"------- Prime Numbers from {num} -------");
            foreach (int i in res)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
        }

        public static void ExtractString()
        {
            string input = "##abc##def";
            
            string[] array = input.Split(new string[] { "##" }, StringSplitOptions.None);

            if (array.Length >= 3)
            {
                Console.Write(array[1]);
            }
            else
            {
                Console.WriteLine("No valid input");
            }
            Console.WriteLine();
        }

        public static void FullSequenceOfLetters()
        {
            string alf = "abcdefghijklmnopqrstuvxyzvwæøå";

            string input = "ds";
            
            int indexOfFirst = alf.IndexOf(input.First());
            int indexOfLast = alf.IndexOf(input.Last());
            
            for (int i = indexOfFirst; i <= indexOfLast; i++)
            {
                Console.WriteLine(alf[i]);
            }
        }

        public static void SumAndAverage(int n, int m)
        {
            long count = (long)m - n + 1;
            long sum = count * (2L * n + (count - 1)) / 2;
            double average = (double)sum / count;
            Console.WriteLine(sum + ", " + average);
        }

        public static void DrawTriangle()
        {
            int height = 5;

            for (int i = 1; i <= height; i++)
            {
                for (int space = 1; space <= height - i; space++)
                {
                    Console.Write(" ");
                }
                for (int star = 1; star <= (2 * i - 1); star++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public static void ToThePowerOf(int num, int pow)
        {
            Console.WriteLine(Math.Pow(num, pow));
        }
    }
}