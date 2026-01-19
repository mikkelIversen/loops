using System;
using System.Collections.Generic;
using System.Threading;
using Yatzy.Menu;
using Yatzy.Util;

namespace Yatzy
{
    public class GameManager
    {
        public enum State
        {
            WAITING,
            STARTING,
            THORWING,
            CHOOSING_DICE_SAVE,
            CHOOSING_ENTRY_SAVE,
            ENDED
        }
        
        static GameManager instance;

        public static GameManager get()
        {
            if (instance == null) instance = new GameManager();
            return instance;
        }

        public State gameState;
        public Dictionary<string, YatzyEntry> yatzyEntries = new Dictionary<string, YatzyEntry>();
        public Dictionary<string, Menu.Menu> menus = new Dictionary<string, Menu.Menu>();
        public List<Player> players = new List<Player>();
        public Player currentPlayer;
        public Player winner;
        private int round = 0;
        public GameManager()
        {
            setup();
        }

        public void setup()
        {
            // SETUP YATZY ENTRIES
            yatzyEntries.Add("Ones", new YatzyOnes());
            yatzyEntries.Add("Twos", new YatzyTwos());
            yatzyEntries.Add("Threes", new YatzyThrees());
            yatzyEntries.Add("Fours", new YatzyFours());
            yatzyEntries.Add("Fives", new YatzyFives());
            yatzyEntries.Add("Sixes", new YatzySixes());
            yatzyEntries.Add("One Pair", new YatzyPairOne());
            yatzyEntries.Add("Two Pair", new YatzyPairTwo());
            yatzyEntries.Add("Small Straight", new YatzyStraightSmall());
            yatzyEntries.Add("Large Straight", new YatzyStraightLarge());
            yatzyEntries.Add("Full House", new YatzyHouse());
            yatzyEntries.Add("Chance", new YatzyChance());
            yatzyEntries.Add("Yatzy", new YatzyYatzy());
            
            menus.Add("main", new MainMenu());
            menus.Add("win", new End());
            
            gameState = State.WAITING;
        }

        public string openMenu(string menu)
        {
            if(!menus.ContainsKey(menu)) return "could not find menu: " + menu;
            menus[menu].open(this);
            return null;
        }
        public void start()
        {
            Console.Clear();

            currentPlayer =  players[0];
            
            while (gameState != State.ENDED)
            {
                tick();
            }
        }
        
        public string addPlayer()
        {
            Console.WriteLine("Enter player name:");
            string playerName = Console.ReadLine();
            Player player = new Player();
            player.username =  playerName;
            players.Add(player);
            
            return "Successfully added " + playerName;
        }
        public string removePlayer()
        {
            Console.WriteLine("Enter player name:");
            string playerName = Console.ReadLine();
            foreach (Player player in players)
            {
                if (player.username == playerName) 
                {
                    players.Remove(player);
                    return "Successfully removed " + playerName;
                }
            }

            return "Could not find a player named: " + playerName;
        }

        public string startCountdown()
        {
            if (players.Count < 2) return "You need to have at least 2 players!";
            gameState = State.STARTING;
            return null;
        }

        public void tick()
        {
            round++;
            Console.Clear();
            DrawScoreboard.drawScoreboard(this);
            switch (gameState)
            {
                case State.STARTING:
                    gameState = State.THORWING;
                    break;
                case State.THORWING:
                    int[] rolls = Dice.ThrowDice(5 - currentPlayer.savedDice.Count);
                    string[] stringRolls = new string[rolls.Length];
                    for (int i = 0; i < rolls.Length; i++)
                    {
                        stringRolls[i] = rolls[i].ToString();
                    }

                    gameState = State.CHOOSING_DICE_SAVE;
                    List<int> choosed = DrawGameOption.open(stringRolls, DrawGameOption.Type.SWITCH);
                    for (int i = 0; i < choosed.Count; i++)
                    {
                        currentPlayer.savedDice.Add(choosed[i]);
                    }

                    if (currentPlayer.savedDice.Count > 4)
                    {
                        currentPlayer.savedDice.Sort();
                        gameState = State.CHOOSING_ENTRY_SAVE;
                        Console.Clear();
                        DrawScoreboardSelector.draw(this);
                        
                        currentPlayer.savedDice = new List<int>();
                        currentPlayer = getNextPlayer();
                        gameState = State.THORWING;
                    }
                    else
                    {
                        gameState = State.THORWING;
                    }
                    break;
            }

            if (round >= 13)
            {
                gameState = State.ENDED;
                Thread.Sleep(3000);
                openMenu("win");
            }
        }


        Player getNextPlayer()
        {
            int currentIndex = players.IndexOf(currentPlayer);
            if(currentIndex == players.Count - 1) currentIndex = 0;
            else currentIndex++;
            return players[currentIndex];
        }
    }
}