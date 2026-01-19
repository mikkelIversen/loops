using System;
using System.Security.Cryptography;

namespace TerningeKast
{
    public class Dice
    {
        private int sides;

        public Dice(int sides)
        {
            this.sides = sides;
        }

        public int getSides()
        {
            return sides;
        }

        public int roll()
        {
            return new Random().Next(1, sides);
        }
    }
}