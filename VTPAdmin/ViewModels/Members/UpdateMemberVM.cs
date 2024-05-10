using System.ComponentModel.DataAnnotations;

namespace VTPAdmin.ViewModels.Members
{
    public class UpdateMemberVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string StudiedAt { get; set; }
        [Required]
        public string Field { get; set; }
        [Required]
        public string StudyYear { get; set; }
        [Required]
        public string Degree { get; set; }
    }
}
