using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal_UF1
{
    #region Objecte Club
    [Serializable()]
    public class Club
    {
        #region variables
        private soci[] _socis;

        public soci[] socis
        {
            get { return _socis; }
            set { _socis = value; }
        }
        #endregion

        #region valors per defecte
        public Club()
        {
            this.socis = new soci[0];
        }
        #endregion

        #region Constructor
        public Club(soci[] socis)
        {
            this.socis = socis;
        }
        #endregion
    }
    #endregion

    #region Objecte soci
    [Serializable()]
    public class soci
    {
        #region variables
        private int _numeroSoci;
        private string _nom;
        private string _cognoms;
        private string _dni;
        private bool _federat;
        private int _edat;

        public string nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public string cognoms
        {
            get { return _cognoms; }
            set { _cognoms = value; }
        }
        public string dni
        {
            get { return _dni; }
            set { _dni = value; }
        }
        public int edat
        {
            get { return _edat; }
            set { _edat = value; }
        }
        public int numeroSoci
        {
            get { return _numeroSoci; }
            set { _numeroSoci = value; }
        }
        public bool federat
        {
            get { return _federat; }
            set { _federat = value; }
        }

        #endregion

        #region valors per defecte
        public soci()
        {
            this.nom = "John";
            this.cognoms = "Doe";
            this.dni = "00000000A";
            this.edat = 18;
            this.numeroSoci = 0;
            this.federat = false;
        }
        #endregion

        #region Constructor
        public soci(int numero, string nom, string cognoms, string dni, bool federat, int edat)
        {
            this.numeroSoci = numero;
            this.nom = nom;
            this.cognoms = cognoms;
            this.dni = dni;
            this.federat = federat;
            this.edat = edat;
        }
        #endregion
    }
    #endregion
}
