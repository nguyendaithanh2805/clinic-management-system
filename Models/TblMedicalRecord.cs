using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblMedicalRecord
{
    public int MedicalRecordId { get; set; }

    public int PatientId { get; set; }

    public string Diagnoses { get; set; } = null!;

    public string Treatments { get; set; } = null!;

    public virtual TblPatient Patient { get; set; } = null!;

    public virtual ICollection<TblPrescription> TblPrescriptions { get; set; } = new List<TblPrescription>();
}
