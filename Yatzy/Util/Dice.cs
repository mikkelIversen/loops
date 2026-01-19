using System;
using System.Runtime.CompilerServices;

namespace Yatzy.Util
{
    public class Dice
    {
        public static int[] ThrowDice(int count)
        {
            Random random = new Random();
            int[] dice = new int[count];
            for (int i = 0; i < count; i++)
            {
                dice[i] = random.Next(1, 7);
            }
            return dice;
        }
    }
}