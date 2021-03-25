using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crescenti_Ivan_A03
{
	public class Reserva
	{
		#region atributs privats
		DateTime datareserva;
		int horareserva;
		int minutsreserva;
		bool acceptatcondicions;
		string centre;
		int comensals;
		string nom;
		string cognom;
		string email;
		string telefon;
		string comentaris;
		#endregion

		#region propietats public
		public DateTime DataReserva
		{
			get
			{
				return datareserva;
			}
			set
			{
				datareserva = value;
			}
		}

		public int HoraReserva
		{
			get
			{
				return horareserva;
			}
			set
			{
				horareserva = value;
			}
		}

		public int MinutsReserva
		{
			get
			{
				return minutsreserva;
			}
			set
			{
				minutsreserva = value;
			}
		}

		public Boolean AcceptaCondicions
		{
			get
			{
				return acceptatcondicions;
			}
			set
			{
				acceptatcondicions = value;
			}
		}

		public string Centre
		{
			get
			{
				return centre;
			}
			set
			{
				centre = value;
			}
		}

		public int Comensals
		{
			get
			{
				return comensals;
			}
			set
			{
				comensals = value;
			}
		}

		public string Nom
		{
			get
			{
				return nom;
			}
			set
			{
				nom = value;
			}
		}

		public string Cognom
		{
			get
			{
				return cognom;
			}
			set
			{
				cognom = value;
			}
		}

		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}

		public string Telefon
		{
			get
			{
				return telefon;
			}
			set
			{
				telefon = value;
			}
		}

		public string Comentaris
		{
			get
			{
				return comentaris;
			}
			set
			{
				comentaris = value;
			}
		}

		#endregion

		#region metodes publics
		public void Deserialitzar(string ruta, string nom = "reserva.xml")
		{
			// Agafa les propietats de la classe Persona
			XmlSerializer serializer = new XmlSerializer(typeof(Reserva));
			try
			{
				if (Directory.Exists(ruta))
				{
					using (FileStream fs = new FileStream(ruta + "\\" + nom, FileMode.Open))
					{
						// Declaro un objecte de tipus persona on deserialitzo
						Reserva r;
						// El mètode Deserialize em carrega els valors del xml a l'objecte p
						// with data from the XML document. */
						r = (Reserva)serializer.Deserialize(fs);
						// Assigno les propietats a la propia instancia this
						this.DataReserva = r.DataReserva;
						this.HoraReserva = r.HoraReserva;
						this.MinutsReserva = r.MinutsReserva;
						this.AcceptaCondicions = r.AcceptaCondicions;
						this.Centre = r.Centre;
						this.Nom = r.Nom;
						this.Cognom = r.Cognom;
						this.Comensals = r.Comensals;
						this.Email = r.Email;
						this.Telefon = r.Telefon;
						this.Comentaris = r.Comentaris;
					}
				}
				else
                {
					Altres.notficiacio("La ruta de el fitxer no existeix!");
                }
			}
			//En cas que es produeixi algun error (no troba el fitxer...) inicialitzem per defecte
			catch (Exception)
			{
				this.DataReserva = DateTime.Today;
				this.HoraReserva = 0;
				this.MinutsReserva = 0;
				this.AcceptaCondicions = false;
				this.Centre = string.Empty;
				this.Nom = string.Empty;
				this.Cognom = string.Empty;
				this.Comensals = 0;
				this.Email = string.Empty;
				this.Telefon = string.Empty;
				this.Comentaris = string.Empty;
				Altres.notficiacio("El fitxer seleccionat no existeix");
			}

		}

		public void Seritalitzar(string ruta, string nom = "reserva.xml")
		{
            //M'he pres la llibertat de modificar aquesta funcio
            //i la de desrialitzar per ferla de una manera
            //mes robusta i personalitzable

            
			// Agafa les propietats de la classe Reserva
			XmlSerializer serializer = new XmlSerializer(typeof(Reserva));
			// Crea un fitxer amb estructura xml
			try
			{
				if (Directory.Exists(ruta))
				{
					StreamWriter writer = new System.IO.StreamWriter(ruta + "\\" + nom);
					serializer.Serialize(writer, this);
					writer.Close();
				}
				else
                {
					Altres.notficiacio("Impossible emmagatzemar el fitxer, la ruta no existeix", "Error");
                }
			}
            catch
            {
				Altres.notficiacio("Hi ha agut un problema en enregistrar la teva informació", "Error");
            }
		}
		#endregion
	}
}
