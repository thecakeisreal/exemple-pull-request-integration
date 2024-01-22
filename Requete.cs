using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TopScore
{
    /// <summary>
    /// Gère le passage de données entre une interface et un modèle
    /// </summary>
    internal class Requete
    {
        public Dictionary<string, object> Donnees { get; private set; }

        public Requete()
        {
            Donnees = new();
        }

        public void AjouterDonne(string cle, object valeur)
        {
            if(Donnees.ContainsKey(cle))
            {
                throw new ArgumentException($"La clé {cle} est déjà présente dans le dictionnaire de données.");
            }

            Donnees[cle] = valeur;
        }

        public void LierObjet<T>(T objet) where T : class
        {
            HashSet<string> cles = Donnees.Keys.ToHashSet();
            PropertyInfo[] champs = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach(PropertyInfo champ in champs)
            {
                if(Donnees.TryGetValue(champ.Name, out object valeur))
                {
                    champ.SetValue(objet, valeur);
                    cles.Remove(champ.Name);
                }
#if DEBUG
                else
                {
                    Console.WriteLine($"Le champ {champ.Name} ne reçoit pas de valeurs.");
                }
#endif 
            }

#if DEBUG
            // Données passées dans le formulaire qui ne sont pas traités par l'objet
            if(cles.Count > 0)
            {
                Console.WriteLine($"Les clés ({string.Join(", ", cles)}) ne sont pas pris en charge par l'objet.");
            }
#endif 
        }
    }
}
