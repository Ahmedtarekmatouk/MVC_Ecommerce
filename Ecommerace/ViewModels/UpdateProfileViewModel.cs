using System.ComponentModel.DataAnnotations;

namespace Ecommerace.ViewModels
{
    public class UpdateProfileViewModel
    {
        [Required]
        public string UserName {  get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        // public List <string> Addresses { get; set; }
        //public string image {get; set;}
    }
}
