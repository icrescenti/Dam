using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace testMongoDB.Entities
{
    public class Product
    {
        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }
        [BsonElement("name")]
        public String Name
        {
            get;
            set;
        }
        [BsonElement("price")]
        public double Price
        {
            get;
            set;
        }
        [BsonElement("quantity")]
        public int Quantity
        {
            get;
            set;
        }
        [BsonElement("status")]
        public bool Status
        {
            get;
            set;
        }
        [BsonElement("date")]
        public DateTime Date
        {
            get;
            set;
        }
        [BsonElement("categoryId")]
        public int CategoryId
        {
            get;
            set;
        }
        public Product(string name, float price, int quantity, bool status, int categoryId, DateTime date)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
            this.Status = status;
            this.CategoryId = categoryId;
            this.Date = date;
        }
        public override String ToString()
        {
            return String.Format ("id: {0}\nname: {1}\nprice: {2}\nstatus: {3}\ndate: {4}\nidCategory: {5}\n", this.Id, this.Name, this.Price, this.Status, this.Date, this.CategoryId);
        }

    }

}
