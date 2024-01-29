using System;
using System.Collections.Generic;

namespace TopScore.Saisons
{
    /// <summary>
    /// Vue pour saisir une nouvelle saison
    /// </summary>
    internal class VueSaisirSaison : Vue
    {
        /// <summary>
        /// Crée une nouvelle vue pour saisir une saison (ajout ou modifier)
        /// </summary>
        /// <param name="donnees">Les données de la saison à modifier ou null pour un ajout.</param>
        public VueSaisirSaison(Dictionary<string, object> donnees) : base(donnees)
        {

        }

        public override Requete Afficher()
        {
            // Saisie des champs
            DateOnly dateDebut = SaisirDate("Quelle est la date de début ?", donnees.GetValueOrDefault("Debut") as DateOnly?);
            DateOnly dateFin = SaisirDate("Quelle est la date de fin ?", donnees.GetValueOrDefault("Fin") as DateOnly?);

            // Création de la requête
            Requete requete = new(new ControleurSaison().AjouterSaison);
            requete.AjouterDonne("Debut", dateDebut);
            requete.AjouterDonne("Fin", dateFin);

            return requete;
        }
    }
}
