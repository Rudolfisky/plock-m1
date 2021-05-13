using System;
using System.Collections.Generic;
using System.Text;

namespace CL
{
    public class KlantDTO
    {
        public int PersoonInfoID { get; set; }
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public int TelNR { get; set; }
        public string Postcode { get; set; }
        public string HuisNR { get; set; }
        public string Mail { get; set; }
        public DateTime DOB { get; set; }
        public DateTime Aankomst { get; set; }
        public DateTime Vertrek { get; set; }
    }
}
