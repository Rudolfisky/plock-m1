using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plock_m1.Models
{
    public class DagModel
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string DagType { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public DateTime BeginTijd { get; set; }
        public DateTime EindTijd { get; set; }
    }
}
