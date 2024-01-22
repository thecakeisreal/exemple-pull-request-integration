using System;
using System.Collections.Generic;

namespace TopScore
{
    /// <summary>
    /// Affiche le menu principal de l'application. L'utilisateur peut sélectionner une option
    /// </summary>
    internal class MenuApplication : Vue
    {
        /// <summary>
        /// Option du menu avec la string (affiché à l'utilisateur) et le délégué, l'action effectuée.
        /// </summary>
        private static readonly List<KeyValuePair<string, Action<Requete>>> options = new()
        {

        };

        /// <inheritdoc/>
        public override void Afficher(Dictionary<string, object> donnees)
        {
            bool continuer = true;      // Continuer l'exécution du menu après la fonctionnalité

            while(continuer)
            {
                bool erreur = false;    // Afficher le message d'erreur

                Console.WriteLine("=== Menu principal ===");
                Console.WriteLine("Sélectionnez une option. Veuillez saisir le nombre devant la ).");
                int indice = 1;

                foreach(KeyValuePair<string, Action<Requete>> option in options)
                {
                    Console.WriteLine($"{indice}) {option.Key}");
                }
                Console.WriteLine($"0) Quitter");

                if(int.TryParse(Console.ReadLine(), out int choix))
                {
                    if(choix < 0 || choix > options.Count)
                    {
                        erreur = true;
                    }

                    if(choix == 0)
                    {
                        continuer = false;
                    }
                    else
                    {
                        options[choix - 1].Value.Invoke(new());
                    }
                }
                else
                {
                    erreur = true;
                }

                // Affiche le message d'erreur
                if(erreur)
                {
                    Console.WriteLine($"La valeur saisie ne correspond à aucune option valide. Veuillez saisir le nombre devant la ).");
                }
            }
        }

    }
}
