using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TopScore
{
    /// <summary>
    /// DAO de base pour l'ensemble des données manipulées
    /// </summary>
    /// <typeparam name="T">Le type de paramètre utilisé par la DAO</typeparam>
    internal abstract class DAOAbstraite<T> where T : Entite
    {
        /// <summary>
        /// Retourne une connexion à la base de données
        /// </summary>
        /// <returns>Une connexion ouverte à la base de données</returns>
        public SqliteConnection GetConnexion()
        {
            SqliteConnection connection = new("Data Source=donnees.db");
            connection.Open();

            return connection;
        }

        /// <summary>
        /// Liste l'ensemble des éléments contenus 
        /// </summary>
        /// <returns></returns>
        public abstract List<T> ListerTout();

        /// <summary>
        /// Ajoute un élément dans la base de données
        /// </summary>
        /// <param name="element">L'élément qui doit être ajouté</param>
        /// <returns></returns>
        protected abstract int Ajouter(T element);

        /// <summary>
        /// Modifie l'enregistrement d'un élément dans la base de données
        /// </summary>
        /// <param name="element">L'élément à modifier</param>
        protected abstract void Modifier(T element);

        /// <summary>
        /// Sauvegarde l'élément dans la base de données
        /// </summary>
        /// <param name="element">L'élément à enregistrer</param>
        public void Enregistrer(T element)
        {
            if(element.Id is null)
            {
                element.Id = Ajouter(element);
            }
            else
            {
                Modifier(element);
            }
        }
    }
}
