using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblPrescriptionMedicine
{
    public int PrescriptionId { get; set; }

    public int MedicineId { get; set; }

    public int Quantity { get; set; }

    public virtual TblMedicine Medicine { get; set; } = null!;

    public virtual TblPrescription Prescription { get; set; } = null!;
}
