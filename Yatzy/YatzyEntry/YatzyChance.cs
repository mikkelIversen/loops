namespace Yatzy
{
    public class YatzyChance : YatzyEntry
    {
        public override string use(Player player)
        {
            if (player.points.ContainsKey(this)) return "You have already used this entry";
            int score = 0;
            foreach (int dice in player.savedDice)
            {
                score += dice;
            }
            player.points.Add(this, score);
            return "";
        }
    }
}