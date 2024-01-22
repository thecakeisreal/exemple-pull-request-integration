namespace TopScore
{
    /// <summary>
    /// Lance l'application TopScore
    /// </summary>
    internal class Application
    {
        static void Main(string[] args)
        {
            MenuApplication menu = new();
            menu.Afficher(new());
        }
    }
}
