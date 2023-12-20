using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.API.DTO
{
    public class PersonalDataDTO
    {
        public Guid Id { get; set; }
        public enum Sex {male, female } 
        public int Age { get; set; }
        public int DateOfBirth { get; set; }

    }
}
