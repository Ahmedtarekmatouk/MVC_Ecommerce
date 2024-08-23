using System.ComponentModel.DataAnnotations;

namespace Ecommerace.ViewModels
{
    public class RegisterViewModel
    {
        [Required]

        public string UserName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Not Matched")]
        public string ConfirmPassword { get; set; }
    }
}
