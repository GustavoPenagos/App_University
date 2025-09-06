using System;
using System.Collections.Generic;
using App_University.Transversal.Util;
using App_University.Transversal.Utils;
using Microsoft.EntityFrameworkCore;

namespace App_University.Data.Context;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Saradap> Saradaps { get; set; }

    public virtual DbSet<Sarchkl> Sarchkls { get; set; }

    public virtual DbSet<Spriden> Spridens { get; set; }

    public virtual DbSet<Stvadmr> Stvadmrs { get; set; }
    public DbSet<ConsultResult> ConsultResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseOracle("OralcleConnection".GetConectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("CURSO")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Saradap>(entity =>
        {
            entity.HasKey(e => new { e.SaradapPidm, e.SaradapTermCodeEntry, e.SaradapApplNo });

            entity.ToTable("SARADAP");

            entity.Property(e => e.SaradapPidm)
                .HasPrecision(8)
                .HasColumnName("SARADAP_PIDM");
            entity.Property(e => e.SaradapTermCodeEntry)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("SARADAP_TERM_CODE_ENTRY");
            entity.Property(e => e.SaradapApplNo)
                .HasPrecision(2)
                .HasColumnName("SARADAP_APPL_NO");
            entity.Property(e => e.SaradapAdmtCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("SARADAP_ADMT_CODE");
            entity.Property(e => e.SaradapApplDate)
                .HasColumnType("DATE")
                .HasColumnName("SARADAP_APPL_DATE");
            entity.Property(e => e.SaradapApstCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SARADAP_APST_CODE");
            entity.Property(e => e.SaradapApstDate)
                .HasColumnType("DATE")
                .HasColumnName("SARADAP_APST_DATE");
            entity.Property(e => e.SaradapCampCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("SARADAP_CAMP_CODE");
            entity.Property(e => e.SaradapCollCode1)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("SARADAP_COLL_CODE_1");
            entity.Property(e => e.SaradapDegcCode1)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("SARADAP_DEGC_CODE_1");
            entity.Property(e => e.SaradapLevlCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("SARADAP_LEVL_CODE");
            entity.Property(e => e.SaradapMajrCode1)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("SARADAP_MAJR_CODE_1");
            entity.Property(e => e.SaradapProgram1)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("SARADAP_PROGRAM_1");
            entity.Property(e => e.SaradapStypCode)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SARADAP_STYP_CODE");
        });

        modelBuilder.Entity<Sarchkl>(entity =>
        {
            entity.HasKey(e => new { e.SarchklPidm, e.SarchklTermCodeEntry, e.SarchklApplNo, e.SarchklAdmrCode });

            entity.ToTable("SARCHKL");

            entity.Property(e => e.SarchklPidm)
                .HasPrecision(8)
                .HasColumnName("SARCHKL_PIDM");
            entity.Property(e => e.SarchklTermCodeEntry)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("SARCHKL_TERM_CODE_ENTRY");
            entity.Property(e => e.SarchklApplNo)
                .HasPrecision(2)
                .HasColumnName("SARCHKL_APPL_NO");
            entity.Property(e => e.SarchklAdmrCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("SARCHKL_ADMR_CODE");
            entity.Property(e => e.SarchklComment)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SARCHKL_COMMENT");
            entity.Property(e => e.SarchklMandatoryInd)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SARCHKL_MANDATORY_IND");
            entity.Property(e => e.SarchklReceiveDate)
                .HasColumnType("DATE")
                .HasColumnName("SARCHKL_RECEIVE_DATE");
        });

        modelBuilder.Entity<Spriden>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SPRIDEN");

            entity.Property(e => e.SpridenFirstName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SPRIDEN_FIRST_NAME");
            entity.Property(e => e.SpridenLastName)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SPRIDEN_LAST_NAME");
            entity.Property(e => e.SpridenMi)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("SPRIDEN_MI");
            entity.Property(e => e.SpridenPidm)
                .HasPrecision(8)
                .HasColumnName("SPRIDEN_PIDM");
        });

        modelBuilder.Entity<Stvadmr>(entity =>
        {
            entity.HasKey(e => e.StvadmrCode);

            entity.ToTable("STVADMR");

            entity.Property(e => e.StvadmrCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("STVADMR_CODE");
            entity.Property(e => e.StvadmrDesc)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("STVADMR_DESC");
        });

        modelBuilder.Entity<ConsultResult>()
            .HasNoKey();
    }
}
