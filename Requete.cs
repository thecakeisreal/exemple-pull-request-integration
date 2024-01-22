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
        /// <summary>
        /// Données qui sont communiquées entre les vues et les contrôleurs
        /// </summary>
        public Dictionary<string, object> Donnees { get; private set; }

        /// <summary>
        /// Crée une nouvelle requête
        /// </summary>
        public Requete()
        {
            Donnees = new();
        }

        /// <summary>
        /// Ajoute une donnée traitée par la requête
        /// </summary>
        /// <param name="cle">La clé associé à la donnée. Utiliser le nom de la propriété pour permettre la liaison automatique.</param>
        /// <param name="valeur">La clé associé à la donnée.</param>
        /// <exception cref="ArgumentException">Si deux clés sont identiques.</exception>
        public void AjouterDonne(string cle, object valeur)
        {
            if(Donnees.ContainsKey(cle))
            {
                throw new ArgumentException($"La clé {cle} est déjà présente dans le dictionnaire de données.");
            }

            Donnees[cle] = valeur;
        }

        /// <summary>
        /// Lie les données contenues dans la requête à l'objet donné
        /// </summary>
        /// <typeparam name="T">Le type de l'objet lié. Il doit s'agir d'une classe.</typeparam>
        /// <param name="objet">L'objet qui est lié aux données.</param>
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
