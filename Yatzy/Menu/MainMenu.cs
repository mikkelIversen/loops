using System;

namespace Yatzy.Menu
{
    public class MainMenu : Menu
    {
        public override void open(GameManager game)
        {
            string currentMessage = "";
            int currentIndex = 0;
            
            drawOption(currentIndex, currentMessage);
            bool started = false;
            while (!started)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    currentIndex = drawOption(currentIndex - 1, currentMessage);
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    currentIndex = drawOption(currentIndex + 1, currentMessage);
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    switch (currentIndex)
                    {
                        case 0:
                            currentMessage = game.startCountdown();
                            if(currentMessage == null)
                            { 
                                started = true;
                                game.start();
                                continue;
                            };
                            drawOption(currentIndex, currentMessage);
                            break;
                        case 1:
                            currentMessage = game.addPlayer();
                            drawOption(currentIndex, currentMessage);
                            break;
                        case 2:
                            currentMessage = game.removePlayer();
                            drawOption(currentIndex, currentMessage);
                            break;
                    }
                }
            }
        }

        public int drawOption(int i, string message)
        {
            Console.Clear();
            if (i < 0) i = 0;
            if (i > 2) i = 2;
            switch (i)
            {
                case 0:
                    Console.WriteLine("###############################################");
                    Console.WriteLine("###############################################");
                    Console.WriteLine("##                                           ##");
                    Console.WriteLine("##                                           ##");
                    Console.WriteLine("##    Start    Add Player    Remove Player   ##");
                    Console.WriteLine("##      ^                                    ##");
                    Console.WriteLine("##                                           ##");
                    Console.WriteLine("###############################################");
                    Console.WriteLine("###############################################");
                    break;
                case 1:
                    Console.WriteLine("###############################################");
                    Console.WriteLine("###############################################");
                    Console.WriteLine("##                                           ##");
                    Console.WriteLine("##                                           ##");
                    Console.WriteLine("##    Start    Add Player    Remove Player   ##");
                    Console.WriteLine("##                  ^                        ##");
                    Console.WriteLine("##                                           ##");
                    Console.WriteLine("###############################################");
                    Console.WriteLine("###############################################");
                    break;
                case 2:
                    Console.WriteLine("###############################################");
                    Console.WriteLine("###############################################");
                    Console.WriteLine("##                                           ##");
                    Console.WriteLine("##                                           ##");
                    Console.WriteLine("##    Start    Add Player    Remove Player   ##");
                    Console.WriteLine("##                                 ^         ##");
                    Console.WriteLine("##                                           ##");
                    Console.WriteLine("###############################################");
                    Console.WriteLine("###############################################");
                    break;
            }
            if(message != null) Console.WriteLine("\n" + message);
            return i;
        }
    }
}