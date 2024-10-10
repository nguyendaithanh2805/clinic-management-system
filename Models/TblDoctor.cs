using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblDoctor
{
    public int DoctorId { get; set; }

    public string? Name { get; set; }

    public string? Specialization { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual TblUser Doctor { get; set; }

    public virtual ICollection<TblAppointment> TblAppointments { get; set; } = new List<TblAppointment>();
}
