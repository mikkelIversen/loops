using System;
using System.Threading;

namespace Yatzy.Menu
{
    public class End : Menu
    {
        public override void open(GameManager game)
        {
            Player winner = game.winner;
            int length = 43 - winner.username.Length;
            Console.WriteLine("###############################################");
            Console.WriteLine("###############################################");
            Console.WriteLine("##                                           ##");
            Console.WriteLine("##                                           ##");
            Console.WriteLine("##" + new string(' ', length/2) + winner + new string(' ', length/2) + "##");
            Console.WriteLine("##                                           ##");
            Console.WriteLine("##                                           ##");
            Console.WriteLine("###############################################");
            Console.WriteLine("###############################################");
            Thread.Sleep(3000);
        }
    }
}