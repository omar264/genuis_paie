namespace Core.Classe
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class DbSage : DbContext
    {
        public DbSage()
            : base("name=DbSage")
        {
        }
        public virtual DbSet<F_Salarie> F_Salarie { get; set; }

        public virtual DbSet<F_Departement> F_Departement { get; set; }
        public virtual DbSet<F_Service> F_Service { get; set; }
        public virtual DbSet<F_Unite> F_Unite { get; set; }
        public virtual DbSet<F_Enfant> F_Enfant { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_Matricule)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_Nom)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_Prénom)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_NumSécuritéSocial)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_Clé)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_CIN)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_ComplementAdresse)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_CodePostal)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_Portable)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_Banque)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_Guichet)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_Compte)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_CléCompte)
                .IsUnicode(false);

            modelBuilder.Entity<F_Salarie>()
                .Property(e => e.SA_LibelléCompte)
                .IsUnicode(false);

            modelBuilder.Entity<F_Departement>()
               .Property(e => e.DP_Code)
               .IsUnicode(false);

            modelBuilder.Entity<F_Departement>()
                .Property(e => e.DP_intitule)
                .IsUnicode(false);

            modelBuilder.Entity<F_Service>()
                .Property(e => e.SE_Code)
                .IsUnicode(false);

            modelBuilder.Entity<F_Service>()
                .Property(e => e.SE_intitule)
                .IsUnicode(false);

            modelBuilder.Entity<F_Unite>()
                .Property(e => e.UN_Code)
                .IsUnicode(false);

            modelBuilder.Entity<F_Unite>()
                .Property(e => e.UN_intitule)
                .IsUnicode(false);
        }
    }
}
