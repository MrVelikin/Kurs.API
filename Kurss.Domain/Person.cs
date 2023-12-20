using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurss.Domain
{
    public class Person
    {
        public Guid Id { get; set; }

        public string Name { get; set; }    
        public string Email { get; set; } 
        public PersonalData? PersonalData { get; set; } = null;
        public List <Documents> Documents { get; set; } = new List<Documents>();
        public List<Pasport> Pasports { get; set; } = new List<Pasport>();
        public List<Sertificate> Sertificates { get; set; } = new List<Sertificate>();


        public Person(String Name,String Email) {
            Id = Guid.NewGuid();
            this.Name = Name;
            this.Email = Email;
        } 

        public void AddPasport(Pasport pasport)
        {
            Pasports.Add(pasport);
        }

        public void AddSertificate(Sertificate Sertificate)
        {
            Sertificates.Add(Sertificate);
        }



    }
}
