using System.ComponentModel.DataAnnotations;

namespace Security_Door_App.Logic.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
       
        public string  Gender { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
       
        public string Comment { get; set; }
        [Required]
        [EmailAddress]
        public string  Email { get; set; }
        [Required]
        public string  Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string?  Role { get; set; }
    }
}
