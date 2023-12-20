using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurss.Domain
{
    public class Address :Documents
    {
        public String Country { get; set; }

        public String City { get; set; }

        public String Street { get; set; }  
        
        public int House { get; set; }

        public int Flat { get; set; }

        public Address(string country, string city, string street, int house, int flat,String DocName, bool Visible):base(DocName,Visible)
        {
            Country = country;
            City = city;
            Street = street;
            House = house;
            Flat = flat;
        }
    }
}
