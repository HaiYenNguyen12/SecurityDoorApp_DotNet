using System.ComponentModel.DataAnnotations;

namespace Security_Door_App.MVC.Models
{
    public class FormModel
    {
        [Required]
        public string CardUniqueNumber { get; set; }
        [Required]
        public string DoorReaderSerialNumber { get; set; }
    }
}
