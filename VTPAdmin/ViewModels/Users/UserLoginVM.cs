using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VTPAdmin.ViewModels.Users
{
    public class UserLoginVM
    {
        
        [EmailAddress]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
