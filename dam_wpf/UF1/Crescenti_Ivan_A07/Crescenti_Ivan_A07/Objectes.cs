using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crescenti_Ivan_A07
{
    [Serializable()]
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoPath { get; set; }

        public Employee(
            string first_name = "Joe", 
            string last_name = "Doe",
            string addresss = "0 E. No Way",
            string postal_code = "0000",
            string city = "Night City",
            string country = "US",
            string photo_path = "img/John_Tran.jpg"
        )
        {
            this.FirstName = first_name;
            this.LastName = last_name;
            this.Address = addresss;
            this.PostalCode = postal_code;
            this.City = city;
            this.Country = country;
            this.PhotoPath = photo_path;
        }

        public Employee() { }
    }
}
