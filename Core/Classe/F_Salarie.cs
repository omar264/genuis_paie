namespace Core.Classe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class F_Salarie
    {
        [Key]
        public int cbMarq { get; set; }

        [StringLength(69)]
        public string SA_Matricule { get; set; }

        public short? SA_Civilté { get; set; }

        public string SA_Nom { get; set; }

        public string SA_Prénom { get; set; }

        public short? SA_SituationFamilliale { get; set; }

        public int? SA_NombreEnfants { get; set; }

        public DateTime? SA_DateNaissance { get; set; }

        public Decimal? SalaireDeBase {get; set; }

        [StringLength(39)]
        public string SA_NumSécuritéSocial { get; set; }

        [StringLength(39)]
        public string SA_Clé { get; set; }

        [StringLength(39)]
        public string SA_CIN { get; set; }

        public DateTime? SA_DateLivraisonCin { get; set; }

        public string SA_Adresse { get; set; }

        public string SA_ComplementAdresse { get; set; }

        [StringLength(39)]
        public string SA_CodePostal { get; set; }

        [StringLength(39)]
        public string SA_Telephone { get; set; }

        [StringLength(39)]
        public string SA_Portable { get; set; }

        [StringLength(39)]
        public string SA_Banque { get; set; }

        [StringLength(39)]
        public string SA_Guichet { get; set; }

        [StringLength(39)]
        public string SA_Compte { get; set; }

        [StringLength(39)]
        public string SA_CléCompte { get; set; }

        public string SA_LibelléCompte { get; set; }
        public string DP_Code { get; set; }
        public string SE_Code { get; set; }
        public string UN_Code { get; set; }
        public DateTime? SA_DateSortie { get; set; }
        public decimal? salaireBase { get; set; }
        public decimal? primes { get; set; }
        public decimal? retenueCnss { get; set; }
        public decimal? retenueIrpp { get; set; }
        public decimal? Css { get; set; }

    }
}
