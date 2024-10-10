using clinic_management_system.Models;

namespace clinic_management_system.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }

        public int RoleId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public virtual TblRole Role { get; set; }

        public virtual TblDoctor? TblDoctor { get; set; }

        public virtual TblStaff? TblStaff { get; set; }
    }
}
