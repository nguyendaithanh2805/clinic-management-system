using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblMedicalService
{
    public int MedicalServiceId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual ICollection<TblAppointment> TblAppointments { get; set; } = new List<TblAppointment>();
}
