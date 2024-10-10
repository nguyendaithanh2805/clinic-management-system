using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblPatient
{
    public int PatientId { get; set; }

    public string Name { get; set; }

    public int? Age { get; set; }

    public bool? Gender { get; set; }

    public string? Address { get; set; }

    public string Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<TblAppointment> TblAppointments { get; set; } = new List<TblAppointment>();

    public virtual ICollection<TblMedicalRecord> TblMedicalRecords { get; set; } = new List<TblMedicalRecord>();
}
