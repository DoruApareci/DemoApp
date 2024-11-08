namespace DemoApp.Shared.Models
{
    public class Dorm
    {
        public Guid DormId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Floors { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}