using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nht_2310900105_De01.Models;

public partial class NguyenHuuTuyen2310900105De01Context : DbContext
{
    public NguyenHuuTuyen2310900105De01Context()
    {
    }

    public NguyenHuuTuyen2310900105De01Context(DbContextOptions<NguyenHuuTuyen2310900105De01Context> options)
        : base(options)
    {
    }

    public virtual DbSet<NhtCategory> NhtCategories { get; set; }

    public virtual DbSet<NhtComputer> NhtComputers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BE78S1Q\\TUYENCHUYENVAN5;Database=NguyenHuuTuyen_2310900105_de01;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NhtCategory>(entity =>
        {
            entity.HasKey(e => e.NhtCateId).HasName("PK__NhtCateg__90C860E0BCD20D78");

            entity.ToTable("NhtCategory");

            entity.Property(e => e.NhtCateId).HasColumnName("nhtCateId");
            entity.Property(e => e.NhtCateName)
                .HasMaxLength(100)
                .HasColumnName("nhtCateName");
        });

        modelBuilder.Entity<NhtComputer>(entity =>
        {
            entity.HasKey(e => e.NhtComId).HasName("PK__NhtCompu__ADA213E4AB4D4DE0");

            entity.ToTable("NhtComputer");

            entity.Property(e => e.NhtComId).HasColumnName("nhtComId");
            entity.Property(e => e.NhtCateId).HasColumnName("nhtCateId");
            entity.Property(e => e.NhtComImage)
                .HasMaxLength(255)
                .HasColumnName("nhtComImage");
            entity.Property(e => e.NhtComName)
                .HasMaxLength(100)
                .HasColumnName("nhtComName");
            entity.Property(e => e.NhtComPrice).HasColumnName("nhtComPrice");
            entity.Property(e => e.NhtComStatus).HasColumnName("nhtComStatus");

            entity.HasOne(d => d.NhtCate).WithMany(p => p.NhtComputers)
                .HasForeignKey(d => d.NhtCateId)
                .HasConstraintName("FK__NhtComput__nhtCa__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
