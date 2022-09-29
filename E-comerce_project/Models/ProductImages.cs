using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_comerce_project.Models
{
    public class ProductImages
    {
        [Key]
        public int Id { get; set; }
        public string ProductImage { get; set; }
        public int ProId { get; set; }
        [ForeignKey("ProId")]
        public virtual Product Product { get; set; }

    }
}
