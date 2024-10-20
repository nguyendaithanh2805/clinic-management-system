using System;
using System.Collections.Generic;

namespace clinic_management_system.Models;

public partial class TblUser
{
    public int UserId { get; set; }

    public int? RoleId { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public virtual TblRole? Role { get; set; }

    public virtual TblDoctor? TblDoctor { get; set; }

    public virtual TblStaff? TblStaff { get; set; }
}
