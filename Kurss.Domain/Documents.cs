using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurss.Domain
{
    public class Documents 
    {
        public Guid Id { get; set; }

        public string DocName { get; set; } = String.Empty;
        public bool Visible { get; set; }= true;

        public List<Pasport> Pasports { get; set; } = new List<Pasport>();

        public List<Sertificate> Sertificates { get; set; } = new List<Sertificate>();

        public Documents(string DocName, bool Visible)
        {
            Id = Guid.NewGuid();
            this.DocName = DocName;
            this.Visible = Visible;

        }
    }
}
