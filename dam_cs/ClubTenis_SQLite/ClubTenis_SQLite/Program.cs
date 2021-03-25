using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubTenis_SQLite
{
    class Program
    {
        struct Soci
        {
            public int id;
            public string nom;
            public string cognom;
            public string dni;
            public int federat;
        }

        struct Pista
        {
            public int id;
            public string tipus;
            public int llum;
        }


        static void Main(string[] args)
        {
            bool existent;
            SQLiteConnection conn;

            existent = File.Exists(Environment.CurrentDirectory + "/clubtenis.db");

            conn = new SQLiteConnection("Data Source=clubtenis.db;Version=3;New=" + existent + ";Compress=True;");

            try { conn.Open(); }
            catch { Console.WriteLine("No ha estat possible connectarse amb la base de dades clubtenis.db"); Console.ReadLine(); return; }

            if (!existent)
            {
                #region creacio taules
                crearTaula(conn, "socis", new string[] {
                    "numero_soci INTEGER(4) NOT NULL PRIMARY KEY,",
                    "nom VARCHAR(25) NOT NULL,",
                    "cognom VARCHAR(25) NOT NULL,",
                    "dni VARCHAR(25) NOT NULL,",
                    "federat INTEGER(1) NOT NULL"
                });
                Console.WriteLine("Taula de Socis creada");

                crearTaula(conn, "pistes", new string[] {
                    "numero_pista INTEGER(4) NOT NULL PRIMARY KEY,",
                    "tipus_esport VARCHAR(25) NOT NULL,",
                    "llum INTEGER(1) NOT NULL"
                });
                Console.WriteLine("Taula de Pistes creada");
                #endregion

                #region socis
                Soci[] socis = new Soci[2];

                socis[0].id = 1;
                socis[0].nom = "Juan";
                socis[0].cognom = "Castilla";
                socis[0].dni = "19643H";
                socis[0].federat = 1;

                socis[1].id = 2;
                socis[1].nom = "Pablo";
                socis[1].cognom = "Guzman";
                socis[1].dni = "1832675G";
                socis[1].federat = 0;
                #endregion

                foreach (Soci sc in socis)
                {
                    InserirInformacio(conn, "socis", sc);
                }
                Console.WriteLine("Informacio de socis de mostra inserida");

                #region pistes
                Pista[] pistes = new Pista[2];

                pistes[0].id = 1;
                pistes[0].tipus = "padel";
                pistes[0].llum = 1;

                pistes[1].id = 2;
                pistes[1].tipus = "squash";
                pistes[1].llum = 0;
                #endregion

                foreach (Pista p in pistes)
                {
                    InserirInformacio(conn, "pistes", p);
                }
                Console.WriteLine("Informacio de pistes inserida");
            }

            #region busquedas
            SQLiteCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT * FROM socis;";
            SQLiteDataReader resultat = cmd.ExecuteReader();
            Console.WriteLine("========================Socis=========================");
            while (resultat.Read())
            {
                string federat;

                if (int.Parse(resultat[4].ToString()) == 1) federat = "Si";
                else federat = "No";

                Console.WriteLine("Id de Soci: " + resultat[0] + "\nNom complert del soci: " + resultat[1] + " " + resultat[2] + "\nDNI: " + resultat[3] + "\nEsta federat: " + federat + "\n--------------------------");
            }
            resultat.Close();

            Console.WriteLine("=======================Pistes========================");

            cmd.CommandText = @"SELECT * FROM pistes;";
            resultat = cmd.ExecuteReader();
            while (resultat.Read())
            {
                string iluminat;

                if (int.Parse(resultat[2].ToString()) == 1) iluminat = "Si";
                else iluminat = "No";

                Console.WriteLine("Id de pista: " + resultat[0] + "\nTipus de esport: " + resultat[1] + "\nEsta iluminada: " + iluminat + "\n--------------------------");
            }
            resultat.Close();
            #endregion

            Console.ReadLine();
        }

        static void crearTaula(SQLiteConnection conn, string nomtaula, params string[] columnes)
        {
            SQLiteCommand com = conn.CreateCommand();
            com.CommandText = "CREATE TABLE IF NOT EXISTS " + nomtaula + " (";

            foreach (string columna in columnes)
            {
                com.CommandText += columna;
            }
            com.CommandText += ");";

            com.ExecuteNonQuery();
        }

        #region funcions per inserir informacio
        static void InserirInformacio(SQLiteConnection conn, string nomtaula, Soci sc)
        {
            SQLiteCommand com = conn.CreateCommand();
            com.CommandText = "INSERT INTO " + nomtaula + " VALUES("+
                sc.id + ", \"" + sc.nom + "\", \"" + sc.cognom + "\", \"" + sc.dni + "\", " + sc.federat + ");"
            ;

            com.ExecuteNonQuery();
        }

        static void InserirInformacio(SQLiteConnection conn, string nomtaula, Pista ps)
        {
            SQLiteCommand com = conn.CreateCommand();
            com.CommandText = "INSERT INTO " + nomtaula + " VALUES(" +
                ps.id + ", \"" + ps.tipus + "\", " + ps.llum + ");"
            ;

            com.ExecuteNonQuery();
        }
        #endregion
    }
}
