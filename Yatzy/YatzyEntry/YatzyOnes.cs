namespace Yatzy
{
    public class YatzyOnes : YatzyEntry
    {
        public override string use(Player player)
        {
            if (player.points.ContainsKey(this)) return "You have already used this entry";
            int score = 0;
            int number = 1;
            int count = player.savedDice.FindAll(d => d == number).Count;
            
            score = number * count;
            player.points.Add(this, score);
            GameManager.get().yatzyEntries["Bonus"].silentUse(player);
            return "";
        }
    }
}