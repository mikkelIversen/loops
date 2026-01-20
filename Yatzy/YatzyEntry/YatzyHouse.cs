using System.Runtime.InteropServices;

namespace Yatzy
{
    public class YatzyHouse : YatzyEntry
    {
        public override string use(Player player)
        {
            player.savedDice.Sort();
            player.savedDice.Reverse();
            if (player.points.ContainsKey(this)) return "You have already used this entry";
            int score = 0;
            bool set2 = false;
            bool set3 = false;
            for (int i = 6; i > 0; i--)
            {
                if (player.savedDice.FindAll(d => d == i).Count > 2 && set3 == false)
                { 
                    score += i*3;
                    set3 = true;
                }
                else if (player.savedDice.FindAll(d => d == i).Count > 1 && set2 == false)
                { 
                    score += i*2;
                    set2 = true;
                };
            }

            if (set2 && set3)
            {
                player.points.Add(this, score);
                return "";
            }

            player.points.Add(this, 0);
            return "";
        }
    }
}