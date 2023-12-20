using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurss.Domain
{
    public class Pasport : Documents
    {
        public String WhoGave { get; set; } = String.Empty;

        public int EndDate { get; set; }
        public int Number { get; set; }

        public Pasport(string whoGave, int endDate, int number, string DocName, bool Visible):base(DocName, Visible)
        {
            WhoGave = whoGave;
            EndDate = endDate;
            Number = number;
        }
        //public Person Person { get; set; } = null!;
    }
}
