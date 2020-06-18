using System.ComponentModel.DataAnnotations;

namespace ManagementStore.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời nhập password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}