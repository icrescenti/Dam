using System;
using System.Data.SQLite;
using System.IO;

namespace SQLiteExample.Persistence
{
    public class DbContext
    {
        private const string DBName = "clubtenis.db";
        private const string SQLScript = @"..\..\Sentencies\creacio.sql";
        private static bool existent = false;

        public static void Up()
        {
            // Crea la base de datos solo una vez
            if (!File.Exists(Path.GetFullPath(DBName)))
            {
                SQLiteConnection.CreateFile(DBName);
                existent = true;
            }

            SQLiteConnection conn = GetInstance();

            // Crea la base de datos solo la primera vez
            if (existent)
            {
                StreamReader reader = new StreamReader(Path.GetFullPath(SQLScript));
                string qry = "";
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    qry += line;
                }

                SQLiteCommand command = new SQLiteCommand(qry, conn);
                command.ExecuteNonQuery();

                for (int i = 1; i <= 100; i++)
                {

                    qry = "INSERT INTO socis (nom, cognom, dni, federat) VALUES (?, ?, ?, ?)";
                    command = new SQLiteCommand(qry, conn);

                    command.Parameters.Add(new SQLiteParameter("nom", "Carlos_" + i));
                    command.Parameters.Add(new SQLiteParameter("cognom", "Arguiñano_" + i));

                    Random rnd = new Random();
                    command.Parameters.Add(new SQLiteParameter("dni", i* rnd.Next(1, 50)));
                    command.Parameters.Add(new SQLiteParameter("federat", rnd.Next(0, 1)));

                    command.ExecuteNonQuery();
                }
            }
        }

        public static SQLiteConnection GetInstance()
        {
            SQLiteConnection db = new SQLiteConnection(string.Format("Data Source={0};Version=3;", DBName));

            try { db.Open(); } catch { 
                Console.WriteLine("Failed connecting to DB");
                Environment.Exit(0);
            }

            return db;
        }
    }
}
