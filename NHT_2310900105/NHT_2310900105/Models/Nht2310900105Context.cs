using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NHT_2310900105.Models;

public partial class Nht2310900105Context : DbContext
{
    public Nht2310900105Context()
    {
    }

    public Nht2310900105Context(DbContextOptions<Nht2310900105Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NhtEmployee> NhtEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BE78S1Q\\TUYENCHUYENVAN5;Database=NHT_2310900105;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NhtEmployee>(entity =>
        {
            entity.HasKey(e => e.NhtEmpId).HasName("PK__NhtEmplo__A245FEAD4EA04DFC");

            entity.ToTable("NhtEmployee");

            entity.Property(e => e.NhtEmpId).ValueGeneratedNever();
            entity.Property(e => e.NhtEmpLevel).HasMaxLength(50);
            entity.Property(e => e.NhtEmpName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
