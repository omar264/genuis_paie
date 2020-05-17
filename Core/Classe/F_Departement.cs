namespace Core.Classe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class F_Departement
    {
        [Key]
        public int DP_No { get; set; }

        [StringLength(69)]
        public string DP_Code { get; set; }

        public string DP_intitule { get; set; }
    }
}
