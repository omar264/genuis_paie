using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Classe
{
    class F_BullteinPaie
    {
        [Key]
     public int BP_NO { get; set; }

        [StringLength(69)]
        public int mois { get; set; }

        public DateTime? SA_DateSortie{ get; set; }   
    }
}
