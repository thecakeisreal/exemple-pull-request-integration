using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopScore.MessagesConfirmation;

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
        /// <returns>La vue générée pour l'ajout de la saison. Soit le formulaire d'ajout ou le message de confirmation</returns>
        public Vue AjouterSaison(Requete requete)
        {
            // Pas de données, alors on affiche le formulaire
            if (!requete.PossedeDonnees)
            {
                return new VueSaisirSaison(null);
            }
            else
            {
                try
                {
                    Saison saison = new();
                    requete.LierObjet(saison);
                    new DAOSaison().Enregistrer(saison);

                    return new MessageSucces("La saison a été ajoutée avec succès !");
                }
                catch (Exception exception)
                {
                    return new MessageErreur(new Dictionary<string, object> {
                        { "Message", $"Une erreur est survenue pendant l'ajout !\n{exception.Message}" }
                    });
                }
            }
        }

        /// <summary>
        /// Liste les saisons dans la vue
        /// </summary>
        /// <param name="requete">Le requête utilisée pour lister</param>
        /// <returns></returns>
        public Vue ListerSaisons(Requete requete)
        {
            return new VueListerSaison(new Dictionary<string, object>
            {
                { "Saisons", new DAOSaison().ListerTout()}
            });
        }
    }
}
