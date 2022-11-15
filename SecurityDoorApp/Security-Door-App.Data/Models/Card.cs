using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Security_Door_App.Data.Models
{
    public class Card
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string IdUser { get; set; }
        public virtual User User { get; set; }
        public string UniqueNumber { get; set; }

        public string Status { get; set; }
        public string Level { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ExpirationTime { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<DoorAction>? DoorActions { get; set; }
    }
}
