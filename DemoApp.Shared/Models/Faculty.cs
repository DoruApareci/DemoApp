using System.ComponentModel.DataAnnotations;

namespace DemoApp.Shared.Models
{
    public class Faculty
    {
        [Key]
        public Guid FacultyId { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
    }
}
