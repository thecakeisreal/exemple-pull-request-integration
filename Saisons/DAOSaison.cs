using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopScore.Saisons
{
    /// <summary>
    /// DAO responsable de la gestion des saisons
    /// </summary>
    internal class DAOSaison : DAOAbstraite<Saison>
    {
        /// <inheritdoc/>
        public override List<Saison> ListerTout()
        {
            SqliteCommand commande = GetConnexion().CreateCommand();
            commande.CommandText =
                @"
                    SELECT debut, fin
                    FROM saison;
                ";

            using SqliteDataReader lecteur = commande.ExecuteReader();

            List<Saison> saisons = new();
            while (lecteur.Read())
            {
                saisons.Add(new Saison
                {
                    Debut = DateOnly.Parse(lecteur.GetString(0)),
                    Fin = DateOnly.Parse(lecteur.GetString(1))
                });
            }

            return saisons;
        }

        /// <inheritdoc/>
        protected override int Ajouter(Saison saison)
        {
            SqliteCommand commande = GetConnexion().CreateCommand();
            commande.CommandText =
                @"
                    INSERT INTO Saison (debut, fin) VALUES ($debut, $fin);
                    SELECT last_insert_rowid();
                ";

            commande.Parameters.AddWithValue("$debut", saison.Debut);
            commande.Parameters.AddWithValue("$fin", saison.Fin);

            return Convert.ToInt32(commande.ExecuteScalar());
        }

        /// <inheritdoc/>
        protected override void Modifier(Saison saison)
        {
            SqliteCommand commande = GetConnexion().CreateCommand();
            commande.CommandText =
                @"
                    UPDATE Saison 
                        SET debut = $debut, 
                            fin = $fin
                        WHERE id = $id;
                ";

            commande.Parameters.AddWithValue("$debut", saison.Debut);
            commande.Parameters.AddWithValue("$fin", saison.Fin);
            commande.Parameters.AddWithValue("$id", saison.Id);

            commande.ExecuteNonQuery();
        }
    }
}
