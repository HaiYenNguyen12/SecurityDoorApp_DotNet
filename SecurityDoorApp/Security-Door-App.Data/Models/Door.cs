namespace Security_Door_App.Data.Models
{
    public class Door
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Level { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<DoorReader>? DoorReaders { get; set; }
    }
}
