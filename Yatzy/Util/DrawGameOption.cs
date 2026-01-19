using System;
using System.Collections.Generic;

namespace Yatzy.Util
{
    public class DrawGameOption
    {
        public enum Type
        {
            SWITCH,
            BUTTON
        }

        public static List<int> open(string[] options, Type type)
        {
            string lastMessage = "Choose what dice's to save";
            draw(options, 0, new List<int>(), lastMessage);

            List<int> selected = new List<int>();
            int index = 0;
            bool exit = false;

            while (!exit)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        index = draw(options, index - 1, selected, lastMessage);
                        break;
                    case ConsoleKey.RightArrow:
                        index = draw(options, index + 1, selected, lastMessage);
                        
                        break;
                    case ConsoleKey.Spacebar:
                        if(!selected.Contains(index + 1)) selected.Add(index + 1);
                        else selected.Remove(index + 1);
                        
                        index = draw(options, index, selected, lastMessage);
                        break;
                    case ConsoleKey.Enter:
                        if (selected.Count < 1)
                        {
                            lastMessage = "Choose at least one dice";
                            index = draw(options, index, selected, lastMessage);
                            break;
                        }
                        exit = true;
                        break;
                }
            }
            List<int> outList = new List<int>();
            foreach (int i in selected)
            {
                outList.Add(Int32.Parse(options[i - 1]));    
            }
            
            return outList;
        }

        static int draw(string[] options, int index, List<int> selected, string message)
        {
            if (index < 0) index = 0;
            if (index >= options.Length) index = options.Length - 1;
            
            Console.Clear();
            DrawScoreboard.drawScoreboard(GameManager.get());

            Console.WriteLine(message);
            for (int i = 0; i < options.Length; i++)
            {
                Console.Write(options[i] + new string(' ', 2));
            }
            Console.Write("\n");
            for(int i = 0; i < options.Length; i++) {
                if (index == i)
                {
                    Console.Write(new string(' ', options[i].Length / 2) + "^" + new string(' ', (options[i].Length / 2) + 2));
                } else if (selected.Contains(i + 1))
                {
                    Console.Write(new string(' ', options[i].Length / 2) + "x" + new string(' ', (options[i].Length / 2) + 2));
                }
                else
                {
                    Console.Write(new string(' ', options[i].Length + 2));
                }
            }
            return index;
        }
    }
}