using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class ApplicationUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string EmailID { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
