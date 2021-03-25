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
        private Stack<Cotxe> _cotxes;
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
        public Stack<Cotxe> Cotxes
        {
            get { return _cotxes; }
            set { _cotxes = value; }
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
        public Concessionari(string Nom, string Poblacio, Stack<Cotxe> Cotxes)
        {
            this.Nom = Nom;
            this.Poblacio = Poblacio;
            this.Cotxes = Cotxes;
        }
        #endregion

        #region metodes del concessionari
        public override string ToString()
        {
            string cotxes = "";

            foreach (Cotxe c in this.Cotxes)
            {
                cotxes += "\n  - " + c.Marca + ", " + c.Model + " per " + c.Preu + "€";
            }

            return string.Format("{0,10} {1,3:d} {2}", this.Nom, this.Poblacio, cotxes);
        }
        public static void afegircotxes(Concessionari obj_concessionari, string fitxer)
        {
            Cotxe c = demanardades("AFEGIR COTXE A LA PILA");

            obj_concessionari.Cotxes.Push(c);
        }
        public static void mostrarcotxes(Concessionari dyncon)
        {
            if (dyncon != null)
            {
                #region mostra els cotxes en stock
                Console.Clear();
                Console.WriteLine("+------------------------+");
                Console.WriteLine("|Cotxes actuals en la cua|");
                Console.WriteLine("+------------------------+");
                Console.WriteLine("{0}", dyncon.ToString());
                Console.ReadLine();
                #endregion
            }
        }
        public static void eliminarcotxeestoc(Concessionari obj_concessionari, string fitxer)
        {
            obj_concessionari.Cotxes.Pop();
        }
        
        #endregion

        #region altres
        static Cotxe demanardades(string titol)
        {
            string marca, model = "";
            float preu = 0.0f;

            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine(titol);
            Console.WriteLine("=======================");
            Console.Write("Marca de el cotxe: ");
            marca = Console.ReadLine();
            Console.Write("Model de el cotxe: ");
            model = Console.ReadLine();
            Console.Write("Preu de el cotxe: ");
            while (!float.TryParse(Console.ReadLine(), out preu))
            {
                Console.WriteLine("[X] Error, el preu no es un valor numeric decimal.");
                Console.Write("Preu de el cotxe: ");
            }

            return new Cotxe(marca, model, preu);
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
