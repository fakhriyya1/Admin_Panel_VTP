namespace VTPAdmin.Models
{
    public class Event : Base
    {
        public string EventName { get; set; }
        public string EventType { get; set; }   //online yoxsa offline
        public string EventPlace { get; set; }  //zoom ve s.
        public string Duration { get; set; }
        public string EventHost { get; set; }
        public string? Guest { get; set; }
        public DateTime EventDate { get; set; }
    }
}
