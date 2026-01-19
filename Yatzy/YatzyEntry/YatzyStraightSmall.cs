namespace Yatzy
{
    public class YatzyStraightSmall : YatzyEntry
    {
        public override string use(Player player)
        {
            if (player.points.ContainsKey(this)) return "You have already used this entry";
            
            if (player.savedDice.Contains(1) && player.savedDice.Contains(2) &&
                player.savedDice.Contains(3) && player.savedDice.Contains(4) &&
                player.savedDice.Contains(5))
            {
                player.points.Add(this, 15);
                return "";
            }
            player.points.Add(this, 0);
            return "";
        }
    }
}