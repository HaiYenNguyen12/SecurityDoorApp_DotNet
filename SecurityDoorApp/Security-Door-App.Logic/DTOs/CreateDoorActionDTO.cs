using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Security_Door_App.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Security_Door_App.Logic.DTOs
{
    public class CreateDoorActionDTO
    {
        public int IdDoorReader { get; set; }
       
        public int IdCard { get; set; }
 
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now.Date;
    }
}
