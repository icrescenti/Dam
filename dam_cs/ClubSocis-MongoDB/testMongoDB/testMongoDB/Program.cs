using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMongoDB.DAO;
using testMongoDB.Entities;


namespace testMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDAO productDAO = new ProductDAO();
            //productDAO.FindAll();
            //productDAO.FindOne("6068f20ae2c94551c4c18125");
            //productDAO.FindCondition(true);
            //productDAO.FindCondition(1,30);
            //productDAO.FindCondition("2");
            //productDAO.SortAndLimit(3);
            //productDAO.Sum();
            //productDAO.create(new Product("IPhone 6s", 300,4, true, 3, DateTime.Now));
            productDAO.delete("IPhone 6s");
            Console.ReadKey();
        }
    }
}

