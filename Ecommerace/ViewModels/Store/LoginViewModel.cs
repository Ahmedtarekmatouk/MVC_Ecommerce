using System.ComponentModel.DataAnnotations;

namespace Ecommerace.ViewModels.Store
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Store Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
}
