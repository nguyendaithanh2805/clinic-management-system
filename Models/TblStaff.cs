using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblStaff
{
    public int StaffId { get; set; }

    public string? Name { get; set; }

    public string? Shift { get; set; }

    public string? Phone { get; set; }

    public virtual TblUser Staff { get; set; }

    public virtual ICollection<TblClinicRoom> TblClinicRooms { get; set; } = new List<TblClinicRoom>();
}
