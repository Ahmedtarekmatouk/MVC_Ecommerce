using System.ComponentModel.DataAnnotations;

namespace Ecommerace.Areas.Admin.ViewModels
{

    public class RegisterViewModel
    {
        public int id { get; set; }

        [RegularExpression("[a-z]{3,25}", ErrorMessage = "UserName must be lowercase and between 3 to 25 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password does not match the confirmation password.")]
        public string ConfirmPassword { get; set; }
    }
}
