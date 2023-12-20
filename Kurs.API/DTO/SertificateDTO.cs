using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs.API.DTO
{
    public class SertificateDTO :DocumentsDTO
    {
        public String SertName { get; set; } = String.Empty;    
        public String Photo { get; set; } = String.Empty;


    }
}
