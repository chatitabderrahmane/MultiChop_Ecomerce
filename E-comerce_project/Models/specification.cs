using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_comerce_project.Models
{
    public class specification
    {
        [Key]
        public int Id { get; set; }
        [Required]  
        public string Name { get; set; }
        public string Value { get; set; }
        public int ProId { get; set; }
        [ForeignKey("ProId")]
        public Product Product { get; set; }

    }
}
