using System.Collections.Generic;

namespace Yatzy
{
    public class Player
    {
        public string username;

        public List<int> savedDice = new List<int>();

        public Dictionary<YatzyEntry, int> points = new Dictionary<YatzyEntry, int>();
    }
}