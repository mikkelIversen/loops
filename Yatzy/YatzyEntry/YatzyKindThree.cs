namespace Yatzy
{
    public class YatzyKindThree : YatzyEntry
    {
        public override string use(Player player)
        {
            if (player.points.ContainsKey(this)) return "You have already used this entry";
            int score = 0;
            for (int i = 1; i < 7; i++)
            {
                if (player.savedDice.FindAll(d => d == i).Count > 2)
                { 
                    score = i*3;
                    player.points.Add(this, score);
                    return "";
                };
            }

            player.points.Add(this, 0);
            return "";
        }
    }
}