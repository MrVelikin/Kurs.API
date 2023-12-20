using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurss.Domain
{
    public class PersonalData
    {
        public Guid Id { get; set; }
        public enum Sex {male, female} 
        public int Age { get; set; }
        public int DateOfBirth { get; set; }

        public PersonalData(int age, int dateOfBirth)
        {
            Id = new Guid();
            Age = age;
            DateOfBirth = dateOfBirth;
        }
    }
}
