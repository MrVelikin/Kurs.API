using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurss.Domain
{
    public class Sertificate :Documents
    {
        public String SertName { get; set; }
        public String  Photo { get; set; }

        public Sertificate(String SertName, String Photo, string DocName, bool Visible) : base(DocName, Visible)
        {
            this.SertName = SertName;
            this.Photo = Photo;
        }
    }
}
