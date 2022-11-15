using System.ComponentModel.DataAnnotations.Schema;

namespace Security_Door_App.Data.Models
{
    public class DoorReader
    {
        public int Id { get; set; }

        public string SerialNumber { get; set; }

        [ForeignKey("Door")]
        public int IdDoor { get; set; }
        public Door Door { get; set; }
        public string Type { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<DoorAction>? DoorActions { get; set; }
    }
}
