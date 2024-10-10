using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblRole
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
