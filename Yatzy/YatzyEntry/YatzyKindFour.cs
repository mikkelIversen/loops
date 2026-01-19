namespace Yatzy
{
    public class YatzyKindFour : YatzyEntry
    {
        public override string use(Player player)
        {
            if (player.points.ContainsKey(this)) return "You have already used this entry";
            int score = 0;
            for (int i = 1; i < 7; i++)
            {
                if (player.savedDice.FindAll(d => d == i).Count > 3)
                { 
                    score = i*4;
                    player.points.Add(this, score);
                    return "";
                };
            }

            player.points.Add(this, 0);
            return "";
        }
    }
}