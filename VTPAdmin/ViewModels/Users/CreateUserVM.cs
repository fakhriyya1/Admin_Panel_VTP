using System.ComponentModel.DataAnnotations;

namespace VTPAdmin.ViewModels.Users
{
    public class CreateUserVM
    {
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
