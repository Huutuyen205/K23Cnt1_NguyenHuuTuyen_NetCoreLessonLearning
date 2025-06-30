using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NhtLesson10.Models;

public partial class NhtK23cnt1Lesson10DbContext : DbContext
{
    public NhtK23cnt1Lesson10DbContext()
    {
    }

    public NhtK23cnt1Lesson10DbContext(DbContextOptions<NhtK23cnt1Lesson10DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BE78S1Q\\TUYENCHUYENVAN5;Database=NhtK23CNT1_Lesson10Db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CateId).HasName("PK__Category__27638D747AD4F0F5");

            entity.ToTable("Category", tb => tb.HasTrigger("trg_CateStatusConvert"));

            entity.Property(e => e.CateId)
                .ValueGeneratedNever()
                .HasColumnName("CateID");
            entity.Property(e => e.CateName).HasMaxLength(150);
            entity.Property(e => e.CateStatus)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
