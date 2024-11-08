namespace DemoApp.Shared.Models
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int Floor { get; set; }
        public int Beds { get; set; }

        public Guid DormId { get; set; }
        public Dorm Dorm { get; set; }
    }
}
