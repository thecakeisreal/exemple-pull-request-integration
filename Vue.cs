using System;
using System.Collections.Generic;

namespace TopScore
{
    /// <summary>
    /// Classe de base pour toutes les vues du système
    /// </summary>
    internal abstract class Vue
    {
        /// <summary>
        /// Dictionnaire interne des données
        /// </summary>
        protected readonly Dictionary<string, object> donnees;

        /// <summary>
        /// Crée une nouvelle vue avec des données à afficher
        /// </summary>
        /// <param name="donnees">Les données à afficher</param>
        public Vue(Dictionary<string, object> donnees)
        {
            this.donnees = donnees;

            // Réduit les vérifications de référence nulle à effectuer
            this.donnees ??= new();            
        }

        /// <summary>
        /// Affiche la vue avec les données reçues en paramètre.
        /// </summary>
        /// <param name="donnees">Les données utilisées dans l'affichage de la vue.</param>
        /// <return>Les éléments de la requête à effectuer dans le système.</return>
        public abstract Requete Afficher();

        /// <summary>
        /// Affiche le message pour indiquer d'entrer une date dans l'interface et la date saisie. S'il s'agit d'une modification,
        /// la date déjà saisie est affichée.
        /// </summary>
        /// <param name="message">Le message qui accompagne la date</param>
        /// <param name="valeur">La valeur déjà saisie s'il s'agit d'une modification.</param>
        /// <returns>La date saisie ou actuelle si aucune modification n'est apportée.</returns>
        protected DateOnly SaisirDate(string message, DateOnly? valeur)
        {
            Console.WriteLine(message);
            if (valeur != null)
            {
                Console.WriteLine($"Valeur actuelle : {valeur} | Saisissez une chaine vide pour ne pas modifier.");
            }
            Console.WriteLine("Le format de saisie de la date est aaaa-mm-jj (par exemple : 2023-01-26)");

            // On répète la saisie tant que nécessaire
            bool saisieValide = false;
            while (!saisieValide)
            {
                string saisie = Console.ReadLine();
                if (saisie == "" && valeur != null)
                {
                    return valeur.Value;
                }
                if (DateOnly.TryParse(saisie, out DateOnly date))
                {
                    return date;
                }

                Console.WriteLine("Impossible de lire la date. Assurez-vous d'entrer correctement la valeur dans le format aaaa-mm-jj (par exemple : 2023-01-26).");
            }

            return default;
        }
    }
}
