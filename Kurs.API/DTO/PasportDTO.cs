using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.API.DTO
{
    public class PasportDTO : DocumentsDTO
    {
        public String WhoGave { get; set; } = String.Empty;

        public int EndDate { get; set; }
        public int Number { get; set; }


    }
}
