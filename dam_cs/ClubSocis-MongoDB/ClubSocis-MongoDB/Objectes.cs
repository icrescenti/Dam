using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClubSocis_MongoDB
{
    public class Pista
    {
        [BsonId]
        public ObjectId objecteId { get; set; }

        [BsonElement("numero_pista")]
        public int numero_pista { get; set; }
        [BsonElement("tipus")]
        public string tipus { get; set; }
        [BsonElement("llum")]
        public bool llum { get; set; }

        public Pista(int pk, string tipus, bool llum)
        {
            numero_pista = pk;
            this.tipus = tipus;
            this.llum = llum;
        }
    }

    public class Soci
    {
        [BsonId]
        public ObjectId objecteId { get; set; }

        [BsonElement("numero_soci")]
        public int numero_soci { get; set; }
        [BsonElement("nom")]
        public string nom { get; set; }
        [BsonElement("cognom")]
        public string cognom { get; set; }
        [BsonElement("dni")]
        public string dni { get; set; }
        [BsonElement("federat")]
        public bool federat { get; set; }

        public Soci(int pk, string nom, string cognom, string dni, bool federat)
        {
            numero_soci = pk;
            this.nom = nom;
            this.cognom = cognom;
            this.dni = dni;
            this.federat = federat;
        }
    }

    public class Reserva
    {
        [BsonId]
        public ObjectId objecteId { get; set; }

        [BsonElement("reservaId")]
        public int reservaId { get; set; }
        [BsonElement("Pista")]
        public Pista Pista { get; set; }
        [BsonElement("Data")]
        public DateTime Data { get; set; }
        [BsonElement("Socis")]
        public Soci[] Socis { get; set; }

        public Reserva(int id, Pista p, DateTime data, Soci[] scs)
        {
            reservaId = id;
            Pista = p;
            this.Data = data;
            this.Socis = scs;
        }
    }
}
