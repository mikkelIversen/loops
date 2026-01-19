namespace Yatzy
{
    public class YatzyPairTwo : YatzyEntry
    {
        public override string use(Player player)
        {
            player.savedDice.Reverse();
            if (player.points.ContainsKey(this)) return "You have already used this entry";
            int score = 0;
            int pairs = 0;
            for (int i = 1; i < 7; i++)
            {
                if (player.savedDice.FindAll(d => d == i).Count > 1)
                {
                    pairs++;
                    score += i*2;
                };

                if (pairs > 1)
                {
                    break;
                }
            }

            if (pairs < 2)
            {
                player.points.Add(this, 0);
                return "";
            }
            player.points.Add(this, score);
            return "";
        }
    }
}