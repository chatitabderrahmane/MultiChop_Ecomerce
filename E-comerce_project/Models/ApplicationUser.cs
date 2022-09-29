using Microsoft.AspNetCore.Identity;

namespace E_comerce_project.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string Name { get; set; }

        public string City { get; set; }    
        public string Adress { get; set; }

    }
}
