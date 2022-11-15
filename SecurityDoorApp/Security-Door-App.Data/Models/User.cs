using Microsoft.AspNetCore.Identity;

namespace Security_Door_App.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string IdentificationNumber { get; set; }
        public bool IsActive { get; set; }
        public string Comment { get; set; }
    }
}
