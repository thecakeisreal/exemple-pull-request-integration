namespace TopScore
{
    /// <summary>
    /// Lance l'application TopScore
    /// </summary>
    internal class Application
    {
        /// <summary>
        /// Méthode de lancement du programme
        /// </summary>
        /// <param name="args">Arguments fournis au programme, actuellement inutilisé</param>
        static void Main(string[] args)
        {
            DAOAbstraite dAOAbstraite = new DAOAbstraite();
            dAOAbstraite.TestBaseDonnees();

            /*MenuApplication menu = new();
            menu.Afficher(new());*/


            
        }
    }
}
