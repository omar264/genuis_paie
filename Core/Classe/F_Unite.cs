namespace Core.Classe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class F_Unite
    {
        [Key]
        public int UN_No { get; set; }

        [StringLength(69)]
        public string UN_Code { get; set; }

        public string UN_intitule { get; set; }
    }
}
