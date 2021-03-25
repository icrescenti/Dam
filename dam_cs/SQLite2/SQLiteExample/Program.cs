using SQLiteExample.Persistence;
using SQLiteExample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteExample.Entity;

namespace SQLiteExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext.Up();

            foreach(Soci sc in UserService.GetAll())
            {
                Console.WriteLine(string.Format("#{0}: - {1}, {2} - Dni: {3} - F: {4}", sc.Id, sc.Nom, sc.Cognom, sc.Dni, sc.Federat));
            }

            Console.Read();
        }
    }
}
