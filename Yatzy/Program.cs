namespace Yatzy
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                GameManager game = GameManager.get();
                game.openMenu("main");
            }
        }
    }
}