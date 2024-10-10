using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual TblRole Role { get; set; } = null!;

    public virtual TblDoctor? TblDoctor { get; set; }

    public virtual TblStaff? TblStaff { get; set; }
}
