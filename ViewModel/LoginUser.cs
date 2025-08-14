using System.ComponentModel.DataAnnotations;

namespace Goal_Mate.ViewModel
{
    public class LoginUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
