namespace Yatzy
{
    public class YatzyStraightLarge : YatzyEntry
    {
        public override string use(Player player)
        {
            if (player.points.ContainsKey(this)) return "You have already used this entry";
            
            if (player.savedDice.Contains(2) && player.savedDice.Contains(3) &&
                player.savedDice.Contains(4) && player.savedDice.Contains(5) &&
                player.savedDice.Contains(6))
            {
                player.points.Add(this, 20);
                return "";
            }
            player.points.Add(this, 0);
            return "";
        }
    }
}