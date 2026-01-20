namespace Yatzy
{
    public class YatzyYatzy : YatzyEntry
    {
        public override string use(Player player)
        {
            if (player.points.ContainsKey(this)) return "You have already used this entry";
            for (int i = 1; i < 7; i++)
            {
                if (player.savedDice.FindAll(d => d == i).Count > 4)
                { 
                    player.points.Add(this, 50);
                    return "";
                };
            }

            player.points.Add(this, 0);
            return "";
        }
    }
}