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
        /// Données qui sont communiquées entre les vues et les contrôleurs.
        /// </summary>
        public Dictionary<string, object> Donnees { get; private set; }

        /// <summary>
        /// Fonction exécuter lors de la requête.
        /// </summary>
        public Func<Requete, Vue> Fonction { get; private set; }

        /// <summary>
        /// Indique si le dictionnaire possède ou non des données.
        /// </summary>
        public bool PossedeDonnees => Donnees.Count > 0;

        /// <summary>
        /// Crée une nouvelle requête
        /// </summary>
        /// <param name="fonction">La fonction à exécuter dans la requête.</param>
        public Requete(Func<Requete, Vue> fonction)
        {
            Donnees = new();
            Fonction = fonction;
        }

        /// <summary>
        /// Ajoute une donnée traitée par la requête.
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
        /// Exécute la requête puis retourne la prochaine requête à exécuter. La requête est nulle pour un retour au menu principal.
        /// </summary>
        /// <param name="requete">La requete à exécuter.</param>
        /// <returns>La prochaine requête à exécuter, ou null pour le menu principal.</returns>
        public Requete Executer()
        {
            Vue vue = Fonction.Invoke(this);
            return vue.Afficher();
        }

        /// <summary>
        /// Lie les données contenues dans la requête à l'objet donné.
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
