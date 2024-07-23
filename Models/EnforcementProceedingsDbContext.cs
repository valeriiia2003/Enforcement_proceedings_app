using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Enforcement_proceedings_app.Models;

public partial class EnforcementProceedingsDbContext : DbContext
{
    public EnforcementProceedingsDbContext()
    {
    }

    public EnforcementProceedingsDbContext(DbContextOptions<EnforcementProceedingsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Authority> Authorities { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientsCase> ClientsCases { get; set; }

    public virtual DbSet<CourtDecision> CourtDecisions { get; set; }

    public virtual DbSet<EnforcementAgency> EnforcementAgencies { get; set; }

    public virtual DbSet<ExecAuthor> ExecAuthors { get; set; }

    public virtual DbSet<ExecutiveAction> ExecutiveActions { get; set; }

    public virtual DbSet<ExecutiveCase> ExecutiveCases { get; set; }

    public virtual DbSet<ParticipantsType> ParticipantsTypes { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=192.168.0.138;Initial Catalog=EnforcementProceedingsDB; User ID=sa;Password=165415aaBB;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Ukrainian_CI_AS");

        modelBuilder.Entity<Authority>(entity =>
        {
            entity.HasKey(e => e.AuthorityId).HasName("PK__Authorit__52804DABA8E9E1E5");

            entity.Property(e => e.AuthorityId)
                .ValueGeneratedNever()
                .HasColumnName("authority_id");
            entity.Property(e => e.AuthorityCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasDefaultValue("Not found")
                .HasColumnName("authority_code");
            entity.Property(e => e.AuthorityName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("authority_name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__031491A86A7DCE26");

            entity.ToTable("City");

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("city_name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__BF21A424D3A0EEDB");

            entity.HasIndex(e => e.ClientEmail, "UQ__Clients__5F79533646B9E4A5").IsUnique();

            entity.HasIndex(e => e.ClientPhoneNumber, "UQ__Clients__F48965FF5AB6A544").IsUnique();

            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.AdditionalAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("NA")
                .HasColumnName("additional_address");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.ClientAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("client_address");
            entity.Property(e => e.ClientEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("client_email");
            entity.Property(e => e.ClientName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("client_name");
            entity.Property(e => e.ClientPhoneNumber)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("client_phone_number");
            entity.Property(e => e.ClientSurname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Unknown")
                .HasColumnName("client_surname");

            entity.HasOne(d => d.City).WithMany(p => p.Clients)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clients__city_id__412EB0B6");
        });

        modelBuilder.Entity<ClientsCase>(entity =>
        {
            entity.HasKey(e => e.ClientExecutivecaseId).HasName("PK__ClientsC__0814CED6A06F47DE");

            entity.Property(e => e.ClientExecutivecaseId).HasColumnName("client_executivecase_id");
            entity.Property(e => e.ExecCaseId).HasColumnName("exec_case_id");
            entity.Property(e => e.PartpId).HasColumnName("partp_id");

            entity.HasOne(d => d.ExecCase).WithMany(p => p.ClientsCases)
                .HasForeignKey(d => d.ExecCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClientsCa__exec___5070F446");

            entity.HasOne(d => d.Partp).WithMany(p => p.ClientsCases)
                .HasForeignKey(d => d.PartpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClientsCa__partp__5165187F");
        });

        modelBuilder.Entity<CourtDecision>(entity =>
        {
            entity.HasKey(e => e.DecisionId).HasName("PK__CourtDec__7F66496C219E2E15");

            entity.Property(e => e.DecisionId)
                .ValueGeneratedNever()
                .HasColumnName("decision_id");
            entity.Property(e => e.AddtionalText)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("addtional_text");
            entity.Property(e => e.DecisionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("decision_date");
            entity.Property(e => e.ExecutiveCaseId).HasColumnName("executiveCase_id");

            entity.HasOne(d => d.ExecutiveCase).WithMany(p => p.CourtDecisions)
                .HasForeignKey(d => d.ExecutiveCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourtDeci__execu__571DF1D5");
        });

        modelBuilder.Entity<EnforcementAgency>(entity =>
        {
            entity.HasKey(e => e.AgencyId).HasName("PK__Enforcem__7224EBF86AEAB0E0");

            entity.Property(e => e.AgencyId).HasColumnName("agency_id");
            entity.Property(e => e.AgencyName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("agency_name");
            entity.Property(e => e.AgencySurname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasDefaultValue("Unknown")
                .HasColumnName("agency_surname");
            entity.Property(e => e.AuthId).HasColumnName("auth_id");

            entity.HasOne(d => d.Auth).WithMany(p => p.EnforcementAgencies)
                .HasForeignKey(d => d.AuthId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Enforceme__auth___66603565");
        });

        modelBuilder.Entity<ExecAuthor>(entity =>
        {
            entity.HasKey(e => e.FinalcaseId).HasName("PK__ExecAuth__01F7117F28ACA037");

            entity.ToTable("ExecAuthor");

            entity.Property(e => e.FinalcaseId)
                .ValueGeneratedNever()
                .HasColumnName("finalcase_id");
            entity.Property(e => e.AgencyId)
                .HasDefaultValueSql("('In process')")
                .HasColumnName("agency_id");
            entity.Property(e => e.ExActionId).HasColumnName("ex_action_id");

            entity.HasOne(d => d.Agency).WithMany(p => p.ExecAuthors)
                .HasForeignKey(d => d.AgencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExecAutho__agenc__6B24EA82");

            entity.HasOne(d => d.ExAction).WithMany(p => p.ExecAuthors)
                .HasForeignKey(d => d.ExActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExecAutho__ex_ac__6C190EBB");
        });

        modelBuilder.Entity<ExecutiveAction>(entity =>
        {
            entity.HasKey(e => e.ActionId).HasName("PK__Executiv__74EFC21728CE927B");

            entity.ToTable("ExecutiveAction");

            entity.Property(e => e.ActionId)
                .ValueGeneratedNever()
                .HasColumnName("action_id");
            entity.Property(e => e.ActionTaken)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("action_taken");
            entity.Property(e => e.Compensation)
                .HasDefaultValue(0.0)
                .HasColumnName("compensation");
            entity.Property(e => e.DecisionId).HasColumnName("decision_id");
            entity.Property(e => e.ExecutionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("execution_date");

            entity.HasOne(d => d.Decision).WithMany(p => p.ExecutiveActions)
                .HasForeignKey(d => d.DecisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Executive__decis__5CD6CB2B");
        });

        modelBuilder.Entity<ExecutiveCase>(entity =>
        {
            entity.HasKey(e => e.CaseId).HasName("PK__Executiv__A8FF8046C1C4B918");

            entity.ToTable("ExecutiveCase");

            entity.HasIndex(e => e.CaseNumber, "UQ__Executiv__8A402D496F132A6C").IsUnique();

            entity.Property(e => e.CaseId)
                .ValueGeneratedNever()
                .HasColumnName("case_id");
            entity.Property(e => e.CaseNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("case_number");
            entity.Property(e => e.CaseStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("case_status");
            entity.Property(e => e.DescriptionText)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description_text");
            entity.Property(e => e.FillingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("filling_date");
        });

        modelBuilder.Entity<ParticipantsType>(entity =>
        {
            entity.HasKey(e => e.ParticipantTypeId).HasName("PK__Particip__A94DCC8B6B02D3B0");

            entity.ToTable("ParticipantsType");

            entity.Property(e => e.ParticipantTypeId)
                .ValueGeneratedNever()
                .HasColumnName("participant_type_id");
            entity.Property(e => e.ParticipantType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("participant_type");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.PartieId).HasName("PK__Parties__A8F7D7D4CD6ECFD9");

            entity.Property(e => e.PartieId)
                .ValueGeneratedNever()
                .HasColumnName("partie_id");
            entity.Property(e => e.ClientId)
                .HasDefaultValue(0)
                .HasColumnName("client_id");
            entity.Property(e => e.PtypeId).HasColumnName("ptype_id");

            entity.HasOne(d => d.Client).WithMany(p => p.Parties)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Parties__client___45F365D3");

            entity.HasOne(d => d.Ptype).WithMany(p => p.Parties)
                .HasForeignKey(d => d.PtypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Parties__ptype_i__46E78A0C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
