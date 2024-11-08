using System.ComponentModel.DataAnnotations;

namespace DemoApp.Shared.Models
{
    public class HousingRequest
    {
        [Key]
        public Guid HousingRequestId { get; set; }
        public DateTime Placed { get; set; }
        public DateOnly HousingStart { get; set; }
        public TimeSpan Duration { get; set; }

        public Guid ApplicationUserId { get; set; }
        public Guid FacultyId { get; set; }
        public Guid RoomId { get; set; }
    }
}
