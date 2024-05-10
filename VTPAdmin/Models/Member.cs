namespace VTPAdmin.Models
{
    public class Member:Base
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string StudiedAt { get; set; }
        public string Field { get; set; }
        public string StudyYear { get; set; }
        public string Degree { get; set; }
    }
}
