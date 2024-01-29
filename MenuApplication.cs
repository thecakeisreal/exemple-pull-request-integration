using System;
using System.Collections.Generic;
using TopScore.Saisons;

namespace TopScore
{
    /// <summary>
    /// Affiche le menu principal de l'application. L'utilisateur peut sélectionner une option
    /// </summary>
    internal class MenuApplication
    {
        /// <summary>
        /// Option du menu avec la string (affiché à l'utilisateur) et le délégué, l'action effectuée.
        /// </summary>
        private static readonly List<Tuple<string, Func<Requete, Vue>>> options = new()
        {
            Tuple.Create("Lister les saisons", new ControleurSaison().ListerSaisons),
            Tuple.Create("Ajouter une saison", new ControleurSaison().AjouterSaison),
        };

        /// <inheritdoc/>
        public void Afficher()
        {
            bool continuer = true;      // Continuer l'exécution du menu après la fonctionnalité

            while (continuer)
            {
                Console.WriteLine("=== Menu principal ===");
                Console.WriteLine("Sélectionnez une option. Veuillez saisir le nombre devant la ).");
                AfficherOptions();

                TraiterChoix(out bool erreur, out continuer);

                // Affiche le message d'erreur
                if (erreur)
                {
                    Console.WriteLine($"La valeur saisie ne correspond à aucune option valide. Veuillez saisir le nombre devant la ).");
                }
            }
        }

        /// <summary>
        /// Affiche les différentes options du menu
        /// </summary>
        private void AfficherOptions()
        {
            int indice = 1;

            foreach (Tuple<string, Func<Requete, Vue>> option in options)
            {
                Console.WriteLine($"{indice}) {option.Item1}");
            }
            Console.WriteLine($"0) Quitter");
        }

        /// <summary>
        /// Traite le choix que l'utilisateur a fait dans le menu
        /// </summary>
        /// <param name="erreur">Indique s'il y a eu une erreur dans le traitement de la saisie</param>
        /// <param name="continuer">Indique si le menu doit se répéter</param>
        private void TraiterChoix(out bool erreur, out bool continuer)
        {
            erreur = false;
            continuer = true;

            if (int.TryParse(Console.ReadLine(), out int choix))
            {
                // Choix hors des valeurs valides
                if (choix < 0 || choix > options.Count)
                {
                    erreur = true;
                }


                if (choix == 0)
                {
                    // Quitter
                    continuer = false;
                }
                else
                {
                    // Exécute la méthode liée à l'autre choix
                    Requete requete = new(options[choix - 1].Item2);

                    while (requete != null)
                    {
                        requete = requete.Executer();
                    }

                }
            }
            else
            {
                erreur = true;
            }
        }
    }


}
