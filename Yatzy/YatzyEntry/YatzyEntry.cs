namespace Yatzy
{
    public class YatzyEntry
    {
        private string id;

        public virtual string use(Player player)
        {
            return "";
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