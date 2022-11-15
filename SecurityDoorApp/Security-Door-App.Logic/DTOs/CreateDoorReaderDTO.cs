using Security_Door_App.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Security_Door_App.Logic.DTOs
{
    public class CreateDoorReaderDTO
    {
        public string SerialNumber { get; set; }
        public int IdDoor { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }
    }
}
