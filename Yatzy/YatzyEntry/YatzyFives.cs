namespace Yatzy
{
    public class YatzyFives : YatzyEntry
    {
        public override string use(Player player)
        {
            if (player.points.ContainsKey(this)) return "You have already used this entry";
            int score = 0;
            int number = 5;
            int count = player.savedDice.FindAll(d => d == number).Count;
            
            score = number * count;
            player.points.Add(this, score);
            return "";
        }
    }
}