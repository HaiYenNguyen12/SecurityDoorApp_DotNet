using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Security_Door_App.Logic.DTOs
{
    public class LoginDTO
    {

        [Required(ErrorMessage = "ErrorMessageUsername")]
        [MaxLength(50)]
        [MinLength(5)]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [MinLength(5)]
        [Required(ErrorMessage = "ErrorMessagePassword")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}
