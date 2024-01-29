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
    internal abstract class DAOAbstraite<T> where T : class
    {
        /// <summary>
        /// Retourne une connexion à la base de données
        /// </summary>
        /// <returns>Une connexion ouverte à la base de données</returns>
        public SqliteConnection GetConnexion()
        {
            using SqliteConnection connection = new SqliteConnection("Data Source=donnees.db");
            connection.Open();

            return connection;
        }

        /// <summary>
        /// Liste l'ensemble des éléments contenus 
        /// </summary>
        /// <returns></returns>
        public abstract List<T> ListerTout();        
    }
}
