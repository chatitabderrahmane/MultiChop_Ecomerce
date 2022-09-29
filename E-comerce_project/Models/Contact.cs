 
using System.ComponentModel.DataAnnotations;

namespace E_comerce_project.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
