using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crescenti_Ivan_A08
{
    public class OrderDetails
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public float UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }

        public OrderDetails()
        {

        }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipName { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public int ShipVia { get; set; }
        public int ShipAddress { get; set; }
        public int ShipPostalCode { get; set; }
        public DateTime RequiredDate { get; set; }
        public int Freight { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }

        public Order()
        {

        }
    }
}
