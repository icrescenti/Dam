using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcuacionPrimerGrado
{
	public class Parseador
	{
		public int obtenerParte1( String ecuacion)
		{

			String[] partes1 = obtenerPartes12(ecuacion);

			String parte1 = partes1[0].Trim();

			return Int32.Parse(parte1.Substring(0, parte1.Length - 1));
		}

		public int obtenerParte2( String ecuacion)
		{

			String[] partes1 = obtenerPartes12(ecuacion);

			String parte2 = partes1[1].Trim();

			String operador = obtenerOperador(ecuacion);

			if ("-".Equals(operador))
			{
				return Int32.Parse(parte2) * (-1);
			}

			return Int32.Parse(parte2);
		}

		public String obtenerOperador( String ecuacion)
		{
			if (ecuacion.IndexOf('+') > 0)
			{
				return "+";
			}
			else
			{
				return "-";
			}
		}

		public int obtenerParte3( String ecuacion)
		{
			String[] partesEcuacion = ecuacion.Split('=');
			return Int32.Parse(partesEcuacion[1].Trim());
		}

		private String[] obtenerPartes12( String ecuacion)
		{
			String[] partesEcuacion = ecuacion.Split('=');

			String operador = obtenerOperador(ecuacion);

			String[] partes1 = partesEcuacion[0].Split(char.Parse( operador));

			return partes1;
		}
	}
}
