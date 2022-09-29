using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_comerce_project.Models
{
    public class Product
    {
        [Key]
        public int ProId { get; set; }
        [Required]  
        public string Name { get; set; }
        public string Description { get; set;}
        public double Old_Price { get; set; }
        public double New_Price { get; set; }
        public string image1 { get; set; }  
        public string image2 { get; set; }
        
        public string Stock { get; set; }
        public int CatId { get; set; }
        [ForeignKey("CatId")]
        public Category Category { get; set; }
         

    }
}
