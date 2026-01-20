namespace Yatzy
{
    public class YatzyBonus : YatzyEntry
    {
        public override bool silentUse(Player player)
        {
            int score = 0;
            score += GameManager.get().yatzyEntries["Ones"].getPoint(player);
            score += GameManager.get().yatzyEntries["Twos"].getPoint(player);
            score += GameManager.get().yatzyEntries["Threes"].getPoint(player);
            score += GameManager.get().yatzyEntries["Fours"].getPoint(player);
            score += GameManager.get().yatzyEntries["Fives"].getPoint(player);
            score += GameManager.get().yatzyEntries["Sixes"].getPoint(player);
 
            if (score > 62)
            {
                player.points.Add(this, 50);
                return true;
            }
            return false;
        }
    }
}