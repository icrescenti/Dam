using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectesSerialitzacio
{
    #region Objecte de Concessionari
    [Serializable()]
    public class Concessionari
    {
        #region definicio variables, lectura i assignacio de les variables
        private string _nom;
        private string _poblacio;
        private List<Cotxe> _estoc;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }
        public string Poblacio
        {
            get { return _poblacio; }
            set { _poblacio = value; }
        }
        public List<Cotxe> Estoc
        {
            get { return _estoc; }
            set { _estoc = value; }
        }
        #endregion

        #region valors per defecte
        public Concessionari()
        {
            //Concessionari per defecte
            this.Nom = "Porsche";
            this.Poblacio = "Bescanó";
        }
        #endregion

        #region Objecte per a cridar definit les variables
        public Concessionari(string Nom, string Poblacio, List<Cotxe> Estoc)
        {
            this.Nom = Nom;
            this.Poblacio = Poblacio;
            this.Estoc = Estoc;
        }
        #endregion

        #region altres
        public override string ToString()
        {
            string cotxes = "";

            foreach (Cotxe c in this.Estoc)
            {
                cotxes += "\n  - " + c.Marca + ", " + c.Model + " per " + c.Preu + "€";
            }

            return string.Format("{0,10} {1,3:d} {2}", this.Nom, this.Poblacio, cotxes);
        }
        #endregion
    }
    #endregion

    #region Objecte de Cotxe
    [Serializable()]
    public class Cotxe
    {
        #region definicio variables, lectura i assignacio de les variables
        private string _marca;
        private string _model;
        private float _preu;
        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public float Preu
        {
            get { return _preu; }
            set { _preu = value; }
        }
        #endregion

        #region valors per defecte
        public Cotxe()
        {
            //Cotxe per defecte
            this.Marca = "Volkswagen";
            this.Model = "Polo 1.0 EVO 80 Advance 5p";
            this.Preu = 16935.0f;
        }
        #endregion

        #region Objecte per a cridar definit les variables
        public Cotxe(string Marca, string Model, float Preu)
        {
            this.Marca = Marca;
            this.Model = Model;
            this.Preu = Preu;
        }
        #endregion
    }
    #endregion
}
