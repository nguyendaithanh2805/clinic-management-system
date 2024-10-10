using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblClinicRoom
{
    public int ClinicRoomId { get; set; }

    public int StaffId { get; set; }

    public string Type { get; set; }

    public int Capacity { get; set; }

    public virtual TblStaff Staff { get; set; }
}
