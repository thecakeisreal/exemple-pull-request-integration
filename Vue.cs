using System.Collections.Generic;

namespace TopScore
{
    /// <summary>
    /// Classe de base pour toutes les vues du système
    /// </summary>
    internal abstract class Vue
    {
        /// <summary>
        /// Affiche la vue avec les données reçues en paramèter
        /// </summary>
        /// <param name="donnees">Les données utilisées dans l'affichage de la vue.</param>
        public abstract void Afficher(Dictionary<string, object> donnees);
    }
}
