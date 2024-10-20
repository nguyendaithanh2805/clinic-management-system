using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using clinic_management_system.Models;

namespace clinic_management_system.Data;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAppointment> TblAppointments { get; set; }

    public virtual DbSet<TblClinicRoom> TblClinicRooms { get; set; }

    public virtual DbSet<TblDoctor> TblDoctors { get; set; }

    public virtual DbSet<TblMedicalRecord> TblMedicalRecords { get; set; }

    public virtual DbSet<TblMedicalService> TblMedicalServices { get; set; }

    public virtual DbSet<TblMedicine> TblMedicines { get; set; }

    public virtual DbSet<TblPatient> TblPatients { get; set; }

    public virtual DbSet<TblPrescription> TblPrescriptions { get; set; }

    public virtual DbSet<TblPrescriptionMedicine> TblPrescriptionMedicines { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblStaff> TblStaffs { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAppointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("pk_tbl_appointment");

            entity.ToTable("tbl_appointment");

            entity.Property(e => e.AppointmentId)
                .ValueGeneratedNever()
                .HasColumnName("appointmentId");
            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("appointmentDate");
            entity.Property(e => e.DocterId).HasColumnName("docterId");
            entity.Property(e => e.DoctorId).HasColumnName("doctorId");
            entity.Property(e => e.MedicalServiceId).HasColumnName("medicalServiceId");
            entity.Property(e => e.PatientId).HasColumnName("patientId");

            entity.HasOne(d => d.Doctor).WithMany(p => p.TblAppointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_appointment_tbl_doctor");

            entity.HasOne(d => d.MedicalService).WithMany(p => p.TblAppointments)
                .HasForeignKey(d => d.MedicalServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_appointment_tbl_medicalService");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblAppointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_appointment_tbl_patient");
        });

        modelBuilder.Entity<TblClinicRoom>(entity =>
        {
            entity.HasKey(e => e.ClinicRoomId).HasName("pk_tbl_clinicRoom");

            entity.ToTable("tbl_clinicRoom");

            entity.Property(e => e.ClinicRoomId)
                .ValueGeneratedNever()
                .HasColumnName("clinicRoomId");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.StaffId).HasColumnName("staffId");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");

            entity.HasOne(d => d.Staff).WithMany(p => p.TblClinicRooms)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_clinicRoom_tbl_staff");
        });

        modelBuilder.Entity<TblDoctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("pk_tbl_doctor");

            entity.ToTable("tbl_doctor");

            entity.Property(e => e.DoctorId)
                .ValueGeneratedNever()
                .HasColumnName("doctorId");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .HasColumnName("specialization");

            entity.HasOne(d => d.Doctor).WithOne(p => p.TblDoctor)
                .HasForeignKey<TblDoctor>(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_doctor_tbl_user");
        });

        modelBuilder.Entity<TblMedicalRecord>(entity =>
        {
            entity.HasKey(e => e.MedicalRecordId).HasName("pk_tbl_medicalRecord");

            entity.ToTable("tbl_medicalRecord");

            entity.Property(e => e.MedicalRecordId)
                .ValueGeneratedNever()
                .HasColumnName("medicalRecordId");
            entity.Property(e => e.Diagnoses).HasColumnName("diagnoses");
            entity.Property(e => e.PatientId).HasColumnName("patientId");
            entity.Property(e => e.Treatments).HasColumnName("treatments");

            entity.HasOne(d => d.Patient).WithMany(p => p.TblMedicalRecords)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_medicalRecord_tbl_patient");
        });

        modelBuilder.Entity<TblMedicalService>(entity =>
        {
            entity.HasKey(e => e.MedicalServiceId).HasName("pk_tbl_medicalService");

            entity.ToTable("tbl_medicalService");

            entity.Property(e => e.MedicalServiceId)
                .ValueGeneratedNever()
                .HasColumnName("medicalServiceId");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TblMedicine>(entity =>
        {
            entity.HasKey(e => e.MedicineId).HasName("pk_tbl_medicine");

            entity.ToTable("tbl_medicine");

            entity.Property(e => e.MedicineId)
                .ValueGeneratedNever()
                .HasColumnName("medicineId");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TblPatient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("pk_tbl_patient");

            entity.ToTable("tbl_patient");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("patientId");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<TblPrescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("pk_tbl_prescription");

            entity.ToTable("tbl_prescription");

            entity.Property(e => e.PrescriptionId)
                .ValueGeneratedNever()
                .HasColumnName("prescriptionId");
            entity.Property(e => e.Dosage).HasColumnName("dosage");
            entity.Property(e => e.MedicalRecordId).HasColumnName("medicalRecordId");

            entity.HasOne(d => d.MedicalRecord).WithMany(p => p.TblPrescriptions)
                .HasForeignKey(d => d.MedicalRecordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_prescription_tbl_medicalRecord");
        });

        modelBuilder.Entity<TblPrescriptionMedicine>(entity =>
        {
            entity.HasKey(e => new { e.PrescriptionId, e.MedicineId }).HasName("pk_tbl_prescription_medicine");

            entity.ToTable("tbl_prescription_medicine");

            entity.Property(e => e.PrescriptionId).HasColumnName("prescriptionId");
            entity.Property(e => e.MedicineId).HasColumnName("medicineId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Medicine).WithMany(p => p.TblPrescriptionMedicines)
                .HasForeignKey(d => d.MedicineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_prescription_medicine_tbl_medicine");

            entity.HasOne(d => d.Prescription).WithMany(p => p.TblPrescriptionMedicines)
                .HasForeignKey(d => d.PrescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_prescription_medicine_tbl_prescription");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("pk_tbl_role");

            entity.ToTable("tbl_role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("roleId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TblStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("pk_tbl_staff");

            entity.ToTable("tbl_staff");

            entity.Property(e => e.StaffId)
                .ValueGeneratedNever()
                .HasColumnName("staffId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Shift)
                .HasMaxLength(50)
                .HasColumnName("shift");

            entity.HasOne(d => d.Staff).WithOne(p => p.TblStaff)
                .HasForeignKey<TblStaff>(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_staff_tbl_user");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_tbl_user");

            entity.ToTable("tbl_user");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("userId");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tbl_user_tbl_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
