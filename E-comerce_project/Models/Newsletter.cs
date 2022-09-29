using System.ComponentModel.DataAnnotations;

namespace E_comerce_project.Models
{
    public class Newsletter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
