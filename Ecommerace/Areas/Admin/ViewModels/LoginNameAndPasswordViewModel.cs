using System.ComponentModel.DataAnnotations;

namespace Ecommerace.Areas.Admin.ViewModels
{
    public class LoginNameAndPasswordViewModel
    {
        public int id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
