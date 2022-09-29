using System.ComponentModel.DataAnnotations;

namespace E_comerce_project.Models.ViewsModel
{
    public class RegisterVM
    {
         public string? Id { get; set; }    
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string  Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
