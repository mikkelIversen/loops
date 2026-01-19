using System;
using System.Collections.Generic;

namespace Yatzy.Util
{
    public class DrawScoreboard
    { 
        static int paddingAmount = 1;
        
        public static void drawScoreboard(GameManager game)
        {
            int longestEntry = 0;
            foreach (KeyValuePair<string, YatzyEntry> entry in game.yatzyEntries)
            {
                if(entry.Key.Length > longestEntry) longestEntry = entry.Key.Length;
            }
            longestEntry += paddingAmount * 2;
            //Draw names
            drawNames(game, longestEntry);
            foreach (KeyValuePair<string, YatzyEntry> entry in game.yatzyEntries)
            {
                Console.Write('|');
                
                Console.Write($" {entry.Key}" + new String(' ', longestEntry - entry.Key.Length - 1));
                
                Console.Write('|');

                foreach (Player p in game.players)
                {
                    string points = entry.Value.getPoint(p) == -1 ? " " : entry.Value.getPoint(p).ToString();
                    Console.Write(
                        new string(' ', paddingAmount) + $"{points}" +  
                        new string(' ', paddingAmount + p.username.Length - points.Length));
                    Console.Write('|');
                }
                Console.Write('\n');
            }
            Console.WriteLine(new string('-', getUsernameTotalLength(game) + longestEntry + paddingAmount + 1 + game.players.Count));
        }

        static int drawNames(GameManager game, int marginLeft)
        {
            int length = getUsernameTotalLength(game);
            Console.WriteLine(new string('-', length + marginLeft + 2 + game.players.Count));
            Console.Write("| " + game.currentPlayer.username + new string(' ', marginLeft - game.currentPlayer.username.Length - 1) + "|");
            foreach (Player player in game.players)
            {
                string display = new string(' ', paddingAmount) + player.username + new string(' ', paddingAmount);
                Console.Write(display + "|");
            }
            Console.Write("\n");
            Console.WriteLine(new string('-', length + marginLeft + 2 + game.players.Count));
            return length;
        }

        public static int getUsernameTotalLength(GameManager game)
        {
            int length = 0;
            
            foreach (Player player in game.players)
            {
                length += player.username.Length + paddingAmount * 2;
            }
            return length;
        }
    }
}