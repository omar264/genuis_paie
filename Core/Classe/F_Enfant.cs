using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Classe
{
    public class F_Enfant
    {
        [Key]
        public int EN_NO { get; set; }

        [StringLength(69)]
        public string EN_Nom { get; set; }
        [StringLength(69)]
        public string EN_Prenom { get; set; }

        public DateTime? EN_DateNaissance { get; set; }
        public short EN_Sexe { get; set; }
        public short EN_Acharge { get; set; }

        public int SA_NO { get; set; }
       
     }
}
