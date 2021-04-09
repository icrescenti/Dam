using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Ecuacion en formato:
 * 
 * ax + b = c
 *
 * a : parte1
 * b : parte2
 * + : operador
 * c: parte3
 *
 * Solucion:
 * x = (c - b) / a
 * es decir:
 * 
 * x = (parte3 - parte2)/parte1
 */

namespace EcuacionPrimerGrado
{

    public class EcuacionPrimerGrado
    {
		private Parseador parseador = new Parseador();

		public double obtenerResultado(String ecuacion)
		{

			int parte1 = parseador.obtenerParte1(ecuacion);
			int parte2 = parseador.obtenerParte2(ecuacion);

			int parte3 = parseador.obtenerParte3(ecuacion);

			double resultado = (double)((parte3 - parte2)) / (double)(parte1);

			return resultado;
		}

	}

}
