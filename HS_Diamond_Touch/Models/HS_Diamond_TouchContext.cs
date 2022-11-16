using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HS_Diamond_Touch.Models
{
    public partial class HS_Diamond_TouchContext : DbContext
    {
        public HS_Diamond_TouchContext()
        {
        }

        public HS_Diamond_TouchContext(DbContextOptions<HS_Diamond_TouchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bradum> Brada { get; set; }
        public virtual DbSet<Frizer> Frizers { get; set; }
        public virtual DbSet<Frizure> Frizures { get; set; }
        public virtual DbSet<Korisnik> Korisniks { get; set; }
        public virtual DbSet<NailArtist> NailArtists { get; set; }
        public virtual DbSet<Nokti> Noktis { get; set; }
        public virtual DbSet<QA> QAs { get; set; }
        public virtual DbSet<Rezervacija> Rezervacijas { get; set; }
        public virtual DbSet<Usluga> Uslugas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=HS_Diamond_Touch;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bradum>(entity =>
            {
                entity.HasKey(e => e.IdBrada);

                entity.Property(e => e.NazivUsluge).HasMaxLength(100);

                entity.Property(e => e.TrajanjeUsluge).HasMaxLength(50);
            });

            modelBuilder.Entity<Frizer>(entity =>
            {
                entity.HasKey(e => e.IdFrizera);

                entity.ToTable("Frizer");

                entity.Property(e => e.BrojTelefona).HasColumnName("Broj_telefona");

                entity.Property(e => e.Certifikati).HasColumnType("ntext");

                entity.Property(e => e.Email).HasMaxLength(60);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Kvalifikacije)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Slika)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Smjena)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Frizure>(entity =>
            {
                entity.HasKey(e => e.IdFrizure);

                entity.ToTable("Frizure");

                entity.Property(e => e.Cijena)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.NazivUsluge).HasMaxLength(100);

                entity.Property(e => e.TrajanjeUsluge).HasMaxLength(30);
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasKey(e => e.IdKorisnika);

                entity.ToTable("Korisnik");

                entity.Property(e => e.Ime).HasMaxLength(20);

                entity.Property(e => e.Prezime).HasMaxLength(30);

                entity.Property(e => e.Spol)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<NailArtist>(entity =>
            {
                entity.ToTable("NailArtist");

                entity.Property(e => e.BrojTelefona).HasColumnName("Broj_telefona");

                entity.Property(e => e.Certifikati).HasColumnType("ntext");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Kvalifikacije)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Slika)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Smjena)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Nokti>(entity =>
            {
                entity.HasKey(e => e.IdNokti);

                entity.ToTable("Nokti");

                entity.Property(e => e.NazivUsluge).HasMaxLength(100);

                entity.Property(e => e.TrajanjeUsluge)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<QA>(entity =>
            {
                entity.HasKey(e => e.RedniBroj);

                entity.ToTable("Q&A");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.ImePrezime).HasMaxLength(120);

                entity.Property(e => e.Ocjena).HasMaxLength(300);

                entity.Property(e => e.Poruka).HasMaxLength(4000);
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.HasKey(e => e.IdRezervacije);

                entity.ToTable("Rezervacija");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Ime).HasMaxLength(20);

                entity.Property(e => e.Prezime).HasMaxLength(30);

                entity.Property(e => e.Spol)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdFrizeraNavigation)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.IdFrizera)
                    .HasConstraintName("FK_Rezervacija_Frizer");

                entity.HasOne(d => d.IdNailArtistNavigation)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.IdNailArtist)
                    .HasConstraintName("FK_Rezervacija_NailArtist");

                entity.HasOne(d => d.IdUslugaNavigation)
                    .WithMany(p => p.Rezervacijas)
                    .HasForeignKey(d => d.IdUsluga)
                    .HasConstraintName("FK_Rezervacija_Usluga");
            });

            modelBuilder.Entity<Usluga>(entity =>
            {
                entity.HasKey(e => e.IdUsluge);

                entity.ToTable("Usluga");

                entity.Property(e => e.DugaCijena)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ExtraDugaCijena)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.KratkaCijena)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.NazivUsluge).HasMaxLength(100);

                entity.Property(e => e.SrednjaCijena)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TrajanjeUsluge).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
