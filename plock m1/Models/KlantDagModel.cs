using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace plock_m1.Models
{
    public class KlantDagModel
    {
        public int ID { get; set; }
        public bool AankomstSet { get; set; }
        public bool VertrekSet { get; set; }
        public DateTime Aankomst { get; set; }
        public DateTime Vertrek { get; set; }
    }
}
