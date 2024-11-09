using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{
    public class RegisterUserDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        public string Nationality { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Guid RoleId { get; set; } = Guid.Parse("EA94D7FA-8E6F-4F08-D952-08DD004F5278");
    }
}
