using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Candidature.Data.Models;

namespace Candidature.Data.Contexts
{
    public partial class CandidatureContext : DbContext
    {
        public CandidatureContext()
        {
        }

        public CandidatureContext(DbContextOptions<CandidatureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidat> Candidats { get; set; } = null!;
        public virtual DbSet<RefNiveauEtude> RefNiveauEtudes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Candidature;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidat>(entity =>
            {
                entity.ToTable("Candidat");

                entity.Property(e => e.RefNiveauEtudeId).HasColumnName("REF_NiveauEtude_Id");

                entity.HasOne(d => d.RefNiveauEtude)
                    .WithMany(p => p.Candidats)
                    .HasForeignKey(d => d.RefNiveauEtudeId)
                    .HasConstraintName("FK_Candidat_ToREF_NiveauEtude");
            });

            modelBuilder.Entity<RefNiveauEtude>(entity =>
            {
                entity.ToTable("REF_NiveauEtude");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
