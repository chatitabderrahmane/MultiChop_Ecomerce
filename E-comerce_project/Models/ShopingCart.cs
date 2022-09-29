using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_comerce_project.Models
{
    public class ShopingCart
    {
        public int Id { get; set; } 
        public int ProId { get; set; }
        [ForeignKey("ProId")]
        public Product Product { get; set; }   
       
        [Range(1,int.MaxValue)]
        public int Qty { get; set; }   
       
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
