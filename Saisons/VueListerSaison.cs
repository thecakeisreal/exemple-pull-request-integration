using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopScore.Saisons
{
    /// <summary>
    /// Liste toutes les saisons, permet d'en modifier ou d'en supprimer
    /// </summary>
    internal class VueListerSaison : Vue
    {
        /// <inheritdoc/>
        public VueListerSaison(Dictionary<string, object> donnees) : base(donnees) 
        {
        
        }

        /// <inheritdoc/>
        public override Requete Afficher()
        {
            Console.WriteLine("=== Lister les saisons ===");

            List<Saison> saisons = donnees["Saisons"] as List<Saison>;
            saisons.Sort((x, y) => x.Debut.CompareTo(y.Debut));
            for(int i = 0; i < saisons.Count; i++)
            {
                Console.WriteLine($"{i + 1}) Dates : {saisons[i].Debut} au {saisons[i].Fin}");
            }

            return null;
        }
    }
}
