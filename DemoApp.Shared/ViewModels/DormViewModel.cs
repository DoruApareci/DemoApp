namespace DemoApp.Shared.ViewModels
{
    public class DormViewModel
    {
        public Guid DormId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int Occupancy { get; set; }
    }
}
