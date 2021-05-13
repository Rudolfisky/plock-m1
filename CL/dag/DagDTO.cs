using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CL
{
    public class DagDTO
    {
        public int dagID { get; set; }
        public int UserID { get; set; }
        public DateTime Date { get; set; }
        public string DagType { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime BeginTijd { get; set; }
        public DateTime EindTijd { get; set; }
        public int Klanten { get; set; }
    }
}
