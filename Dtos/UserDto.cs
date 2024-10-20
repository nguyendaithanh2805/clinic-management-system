using clinic_management_system.Models;
using System.ComponentModel.DataAnnotations;

namespace clinic_management_system.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }

        public int? RoleId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username must be shorter than 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [StringLength(50, ErrorMessage = "Username must be shorter than 50 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        public virtual TblRole? Role { get; set; }

        public virtual TblDoctor? TblDoctor { get; set; }

        public virtual TblStaff? TblStaff { get; set; }
    }
}
