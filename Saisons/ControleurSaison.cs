using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopScore.Saisons
{
    /// <summary>
    /// Contrôleur des saisons
    /// </summary>
    internal class ControleurSaison : Controleur
    {
        /// <summary>
        /// Ajoute une saison dans les données du système
        /// </summary>
        /// <param name="requete">La requête utilisée pour les données</param>
        public Vue AjouterSaison(Requete requete)
        {
            // Pas de données, alors on affiche le formulaire
            if (!requete.PossedeDonnees)
            {
                return new VueSaisirSaison(null);
            }
            else
            {
                requete.LierObjet(new Saison());
                return new MessageConfirmation(new Dictionary<string, object> {
                    { "Code", 0 },
                    { "Message", "La saison a été ajoutée avec succès !" }
                });
            }
        }
    }
}
