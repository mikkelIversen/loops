namespace Yatzy
{
    public class YatzyEntry
    {
        public virtual string use(Player player)
        {
            return "You cannot use this entry";
        }

        public virtual bool silentUse(Player player)
        {
            return false;
        }

        public int getPoint(Player player)
        {
            if (player.points.ContainsKey(this))
            {
                return player.points[this];
            }
            return -1;
        }
    }
}