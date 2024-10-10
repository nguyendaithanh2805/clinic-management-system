using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblMedicine
{
    public int MedicineId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public virtual ICollection<TblPrescriptionMedicine> TblPrescriptionMedicines { get; set; } = new List<TblPrescriptionMedicine>();
}
