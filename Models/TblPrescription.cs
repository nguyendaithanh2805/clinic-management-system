using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblPrescription
{
    public int PrescriptionId { get; set; }

    public int MedicalRecordId { get; set; }

    public string Dosage { get; set; }

    public virtual TblMedicalRecord MedicalRecord { get; set; }

    public virtual ICollection<TblPrescriptionMedicine> TblPrescriptionMedicines { get; set; } = new List<TblPrescriptionMedicine>();
}
