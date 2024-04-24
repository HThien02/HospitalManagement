using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Models;

public partial class HospitalBackupContext : DbContext
{
    public HospitalBackupContext()
    {
    }

    public HospitalBackupContext(DbContextOptions<HospitalBackupContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Clinic> Clinics { get; set; }

    public virtual DbSet<CovidInfo> CovidInfos { get; set; }

    public virtual DbSet<Medical> Medicals { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PatientDetail> PatientDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<ShiftShedule> ShiftShedules { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-DQGH4NR; database=Hospital_Backup; uid=sa; password=sa; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("Appointment");

            entity.HasIndex(e => e.ClinicId, "IX_Appointment_ClinicID");

            entity.HasIndex(e => e.PatientId, "IX_Appointment_PatientID");

            entity.HasIndex(e => e.UserId, "IX_Appointment_UserID");

            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.AppointmentStatus).HasMaxLength(255);
            entity.Property(e => e.AppointmentTime).HasColumnType("datetime");
            entity.Property(e => e.ClinicId).HasColumnName("ClinicID");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Clinic).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ClinicId)
                .HasConstraintName("FK_Appointment_Clinic");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK_Appointment_Patient");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Appointment_User");
        });

        modelBuilder.Entity<Clinic>(entity =>
        {
            entity.ToTable("Clinic");

            entity.Property(e => e.ClinicId).HasColumnName("ClinicID");
            entity.Property(e => e.ClinicName).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Service).HasMaxLength(255);
        });

        modelBuilder.Entity<CovidInfo>(entity =>
        {
            entity.HasKey(e => e.CovidId);

            entity.ToTable("CovidInfo");

            entity.HasIndex(e => e.UserId, "IX_CovidInfo_UserID");

            entity.Property(e => e.CovidId).HasColumnName("CovidID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TestDate).HasColumnType("datetime");
            entity.Property(e => e.TestResult).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.VaccineStatus).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.CovidInfos)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_CovidInfo_User");
        });

        modelBuilder.Entity<Medical>(entity =>
        {
            entity.ToTable("Medical");

            entity.HasIndex(e => e.AppointmentId, "IX_Medical_AppointmentID");

            entity.Property(e => e.MedicalId).HasColumnName("MedicalID");
            entity.Property(e => e.AppointmentId).HasColumnName("AppointmentID");
            entity.Property(e => e.Diagnosis).HasMaxLength(255);
            entity.Property(e => e.ExaminationDate).HasColumnType("datetime");
            entity.Property(e => e.Prescription).HasMaxLength(255);
            entity.Property(e => e.Symptoms).HasMaxLength(255);

            entity.HasOne(d => d.Appointment).WithMany(p => p.Medicals)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK_Medical_Appointment");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("Patient");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("PatientID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);

            entity.HasOne(d => d.PatientNavigation).WithOne(p => p.Patient)
                .HasForeignKey<Patient>(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Patient_PatientDetail");
        });

        modelBuilder.Entity<PatientDetail>(entity =>
        {
            entity.HasKey(e => e.PatientId);

            entity.ToTable("PatientDetail");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Diagnosis).HasMaxLength(255);
            entity.Property(e => e.ExaminationDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.Prescription).HasMaxLength(255);
            entity.Property(e => e.Symptoms).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleName).HasMaxLength(255);
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.ToTable("Schedule");

            entity.HasIndex(e => e.UserId, "IX_Schedule_UserID");

            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.WorkDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Schedule_User");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.ToTable("Shift");

            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ShiftName).HasMaxLength(255);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ShiftShedule>(entity =>
        {
            entity.HasKey(e => e.ShiftScheduleId);

            entity.ToTable("ShiftShedule");

            entity.HasIndex(e => e.ScheduleId, "IX_ShiftShedule_ScheduleID");

            entity.HasIndex(e => e.ShiftId, "IX_ShiftShedule_ShiftID");

            entity.Property(e => e.ShiftScheduleId).HasColumnName("ShiftScheduleID");
            entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");
            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

            entity.HasOne(d => d.Schedule).WithMany(p => p.ShiftShedules)
                .HasForeignKey(d => d.ScheduleId)
                .HasConstraintName("FK_ShiftShedule_Schedule");

            entity.HasOne(d => d.Shift).WithMany(p => p.ShiftShedules)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK_ShiftShedule_Shift");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);

            entity.HasOne(d => d.UserNavigation).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_UserDetail");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserDetail");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.Gender).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRolesId);

            entity.HasIndex(e => e.RoleId, "IX_UserRoles_RoleID");

            entity.HasIndex(e => e.UserId, "IX_UserRoles_UserID");

            entity.Property(e => e.UserRolesId).HasColumnName("UserRolesID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_UserRoles_Roles");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserRoles_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
