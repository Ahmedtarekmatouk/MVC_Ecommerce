using Ecommerace.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerace.ViewModels.Store
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="Store Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords Don't Match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name ="Country")]
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateId { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        public List<Country>? CountriesList { get; set; }

        //public List<State> StatesList { get; set; }

        //public List<City> CitiesList { get ; set; }
        [Required]
        public string Address { get ; set ; }
    }
}
