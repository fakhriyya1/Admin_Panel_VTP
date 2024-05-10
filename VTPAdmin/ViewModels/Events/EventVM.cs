namespace VTPAdmin.ViewModels.Events
{
    public class EventVM
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string CreatedBy { get; set; }
        public string EventType { get; set; }
        public string EventPlace { get; set; }
        
        public string Duration { get; set; }
        
        public string EventHost { get; set; }
        public string? Guest { get; set; }
        public DateTime EventDate { get; set; }
    }
}
