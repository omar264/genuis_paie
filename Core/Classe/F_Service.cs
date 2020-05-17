namespace Core.Classe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class F_Service
    {
        [Key]
        public int SE_No { get; set; }

        [StringLength(69)]
        public string SE_Code { get; set; }

        public string SE_intitule { get; set; }
    }
}
