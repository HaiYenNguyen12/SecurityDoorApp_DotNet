using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Security_Door_App.Logic.DTOs
{
    public class CreateCardDTO
    {
        public string IdUser { get; set; }
        public string UniqueNumber { get; set; }
        public string Status { get; set; }
        public string  Level { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ExpirationTime { get; set; }
        public string Comment { get; set; }
    }
}
