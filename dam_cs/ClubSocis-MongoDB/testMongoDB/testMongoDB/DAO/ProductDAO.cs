using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using testMongoDB.Entities;

namespace testMongoDB.DAO
{
    public class ProductDAO
    {
        private MongoClient mongoClient;
        private IMongoCollection<Product> productCollection;
        public ProductDAO()
        {
            //mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            //var database = mongoClient.GetDatabase("mydemo");
            mongoClient = new MongoClient("mongodb+srv://campalans:campalans@cluster0.maugj.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            var database = mongoClient.GetDatabase("test1");
            productCollection = database.GetCollection<Product>("product");
        }

        public void FindAll()
        {
            var products = productCollection.AsQueryable<Product>().ToList();
            foreach(Product p in products)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("==========================");
            }
        }

        public void FindOne(string id)
        {
            var productId = new ObjectId(id);
            var products = productCollection.AsQueryable<Product>().SingleOrDefault(p => p.Id == productId);
            Console.WriteLine(products.ToString());
            Console.WriteLine("==========================");
            
        }
        public void FindCondition(bool status)
        {
            var products = productCollection.AsQueryable<Product>().Where(p => p.Status == status).ToList();
            foreach(Product p in products)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("==========================");
            }
        }

        public void FindCondition(double min, double max)
        {
            var products = productCollection.AsQueryable<Product>().Where(p => p.Price >= min && p.Price <= max).ToList();
            foreach (Product p in products)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("==========================");
            }
        }

        public void FindCondition(string keyword)
        {
            var products = productCollection.AsQueryable<Product>().Where(p => p.Name.Contains(keyword)).ToList();
            foreach (Product p in products)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("==========================");
            }
        }

        public void SortAndLimit(int n)
        {
            var products = productCollection.AsQueryable<Product>().OrderByDescending(p => p.Price).Skip(0).Take(n).ToList();
            foreach (Product p in products)
            {
                Console.WriteLine(p.ToString());
                Console.WriteLine("==========================");
            }
        }

        public void Sum()
        {
            int value = productCollection.AsQueryable<Product>().Sum(p => p.Quantity);
            Console.WriteLine("Num: " + value);
            Console.WriteLine("==========================");
        }
        public void create(Product p)
        {
            productCollection.InsertOne(p);
        }
        public void update(string name, int quantity)
        {
            var filter = Builders<Product>.Filter.Eq("name", name);
            var update = Builders<Product>.Update.Set("quantity", quantity);
            var result = productCollection.UpdateOne(filter, update);
            Console.WriteLine("Updated: {0}", result.ModifiedCount);
        }
        /*
        public void delete(string name)
        {
            var filter = Builders<Product>.Filter.Eq("name", name);
            var result = productCollection.DeleteOne(filter);
            Console.WriteLine("Deleted: {0}", result.DeletedCount);
        }
        */

        public void delete(string name)
        {
            var result = productCollection.DeleteOne(p => p.Name == name);
            Console.WriteLine("Deleted: {0}", result.DeletedCount);
        }
    }
}
