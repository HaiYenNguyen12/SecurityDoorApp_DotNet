using System.ComponentModel.DataAnnotations.Schema;

namespace Security_Door_App.Data.Models
{
    public class DoorAction
    {

        public int Id { get; set; }
        [ForeignKey("DoorReader")]
        public int IdDoorReader { get; set; }
        public virtual DoorReader? DoorReader { get; set; }
        [ForeignKey("Card")]
        public int IdCard { get; set; }
        public virtual Card? Card { get; set; }
        public string Status { get; set; }

        [Column(TypeName = "Date")]
        public DateTime TimeStamp { get; set; }
    }
}
