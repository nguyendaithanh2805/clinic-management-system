using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblMedicalRecord
{
    public int MedicalRecordId { get; set; }

    public int PatientId { get; set; }

    public string Diagnoses { get; set; }

    public string Treatments { get; set; }

    public virtual TblPatient Patient { get; set; }

    public virtual ICollection<TblPrescription> TblPrescriptions { get; set; } = new List<TblPrescription>();
}
