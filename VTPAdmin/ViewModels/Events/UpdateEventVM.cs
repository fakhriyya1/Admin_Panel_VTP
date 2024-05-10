using System.ComponentModel.DataAnnotations;

namespace VTPAdmin.ViewModels.Events
{
    public class UpdateEventVM
    {
        [Required]
        public string EventName { get; set; }
        [Required]
        public string EventType { get; set; }
        [Required]
        public string EventPlace { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string EventHost { get; set; }
        public string? Guest { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
    }
}
