using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopScore
{
    internal class DAOAbstraite
    {
        public void TestBaseDonnees()
        {
            using var connection = new SqliteConnection("Data Source=hello.db");
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            @"
                    SELECT nom
                    FROM utilisateur
                    WHERE id = $id
                ";
            command.Parameters.AddWithValue("$id", 1);

            using var reader = command.ExecuteReader();
            while(reader.Read())
            {
                var nom = reader.GetString(0);

                Console.WriteLine($"Hello, {nom}!");
            }
        }
    }
}
