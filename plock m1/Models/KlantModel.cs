using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plock_m1.Models
{
    public class KlantModel
    {
        public int ID { get; set; }
        [Required]
        public string Voornaam { get; set; }
        public string Tussenvoegsel { get; set; }
        [Required]
        public string Achternaam { get; set; }
        public int TelNR { get; set; }
        public string Postcode { get; set; }
        public string StraatNaam { get; set; }
        public string HuisNR { get; set; }
        public string Mail { get; set; }
        public DateTime DOB { get; set; }
    }
}
