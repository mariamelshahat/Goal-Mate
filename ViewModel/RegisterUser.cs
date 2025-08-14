using System.ComponentModel.DataAnnotations;

namespace Goal_Mate.ViewModel
{
    public class RegisterUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        [DataType ( DataType.Password )]
        [Required]
        public string Password { get; set; }

        [DataType ( DataType.Password )]
        [Compare ( "Password", ErrorMessage = "Error Password isnot Correct" )]
        [Required]
        public string ConfirmPassword { get; set; }


    }
}
