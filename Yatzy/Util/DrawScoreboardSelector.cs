using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Yatzy.Util
{
    public class DrawScoreboardSelector
    { 
        static int paddingAmount = 1;

        public static void draw(GameManager game)
        {
            string lastMessage = "Select a entry to store this in";
            int index = 0;
            bool chosen = false;
            index = drawScoreboard(game, index, lastMessage);
            while (!chosen)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                int tempindex = index;
                
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        int k = 0;
                        tempindex++;
                        foreach (KeyValuePair<string, YatzyEntry> entry in game.yatzyEntries.Reverse())
                        {
                            if(k != tempindex) continue;
                            if (entry.Value.getPoint(game.currentPlayer) != -1) tempindex++;
                            k++;
                        }
                        if(tempindex >= game.yatzyEntries.Count) break;
                        
                        index = drawScoreboard(game, tempindex, lastMessage);
                        break;
                    case ConsoleKey.UpArrow:
                        tempindex--;
                        int j = game.yatzyEntries.Count - 1;
                        foreach (KeyValuePair<string, YatzyEntry> entry in game.yatzyEntries.Reverse())
                        {
                            if(j != tempindex) continue;
                            if (entry.Value.getPoint(game.currentPlayer) != -1) tempindex--;
                            j--;
                        }
                        if(tempindex < -1) break;
                        
                        index = drawScoreboard(game, tempindex, lastMessage);
                        break;
                    case ConsoleKey.Enter:
                        int i = 0;
                        YatzyEntry yatzyEntry = null;

                        foreach (KeyValuePair<string, YatzyEntry> entry in game.yatzyEntries)
                        {
                            if(index == i) yatzyEntry = entry.Value;
                            i++;
                        }
                        
                        if(yatzyEntry == null) return;

                        lastMessage = yatzyEntry.use(game.currentPlayer);
                        if (lastMessage.Length == 0)
                        {
                            chosen = true;
                        }
                        index = drawScoreboard(game, index, lastMessage);
                        break;
                }
            }
        }
        
        public static int drawScoreboard(GameManager game, int index, string lastMessage)
        {
            if (index < 0) index = 0;
            if (index >= game.yatzyEntries.Count)  index = game.yatzyEntries.Count - 1;
            
            int longestEntry = 0;
            foreach (KeyValuePair<string, YatzyEntry> entry in game.yatzyEntries)
            {
                if(entry.Key.Length > longestEntry) longestEntry = entry.Key.Length;
            }
            longestEntry += paddingAmount * 2;
            
            Console.Clear();
            //Draw names
            drawNames(game, longestEntry);
            int i = 0;
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

                if (index == i)
                {
                    Console.Write("  <\n");
                }
                else
                {
                    Console.Write('\n');
                }
                
                
                i++;
            }
            Console.WriteLine(new string('-', getUsernameTotalLength(game) + longestEntry + paddingAmount + 1 + game.players.Count));
            Console.WriteLine(lastMessage);
            for (int j = 0; j < game.currentPlayer.savedDice.Count; j++)
            {
                Console.Write(game.currentPlayer.savedDice[j] + new string(' ', 2));
            }
            return index;
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