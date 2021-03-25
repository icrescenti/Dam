using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piles
{
    public class Pila
    {
        Node arrel;
        public Pila()
        {
            arrel = null;
        }

        public void Insertar(int x)
        {
            Node nou;
            nou = new Node();
            nou.info = x;
            if(arrel == null)
            {
                nou.seg = null;
                arrel = nou;
            }
            else
            {
                nou.seg = arrel;
                arrel = nou;
            }
        }
        public int Extreure()
        {
            if(arrel != null)
            {
                int informacio = arrel.info;
                arrel = arrel.seg;
                return informacio;
            }
            else
            {
                return int.MaxValue;
            }
        }
        public void Imprimir()
        {
            Node reco = arrel;
            while (reco != null)
            {
                Console.Write(reco.info + " +");
                reco = reco.seg;
            }
            Console.WriteLine();
        }
        public bool ComprovarBuit()
        {
            if (arrel == null)
                return true;
            else
                return false;
        }
        public int Comptador()
        {
            Node reco = arrel;
            int c = 0;
            while (reco != null)
            {
                c++;
                reco = reco.seg;
            }

            return c;
        }
    }
}
