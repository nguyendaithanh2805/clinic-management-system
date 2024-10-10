using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblMedicine
{
    public int MedicineId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<TblPrescriptionMedicine> TblPrescriptionMedicines { get; set; } = new List<TblPrescriptionMedicine>();
}
