using SQLiteExample.Entity;
using SQLiteExample.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;

namespace SQLiteExample.Service
{
    public class UserService
    {
        public static IEnumerable<Soci> GetAll()
        {
            List<Soci> result = new List<Soci>();

            SQLiteConnection conn = DbContext.GetInstance();
            string qry = "SELECT * FROM socis";

            SQLiteCommand cmd = new SQLiteCommand(qry, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.Add(
                new Soci
                {
                    Id = Convert.ToInt32(reader["numero_soci"].ToString()),
                    Nom = reader["nom"].ToString(),
                    Cognom = reader["cognom"].ToString(),
                    Dni = reader["dni"].ToString(),
                    Federat = Convert.ToInt32(reader["federat"].ToString())
                });
            }

            return result;
        }
    }
}
