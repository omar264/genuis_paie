using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Classe
{
    public class F_BullteinPaie
    {
        [Key]
        public int BP_NO { get; set; }

        public DateTime? SA_DateSortie{ get; set; }   
        public decimal? salaireBase { get; set; } 
        public float? primes { get; set; }
        public float retenueCnss { get; set; }
        public float retenueIrpp { get; set; }

    }
}
