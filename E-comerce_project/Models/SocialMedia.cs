using System.ComponentModel.DataAnnotations;

namespace E_comerce_project.Models
{
    public class SocialMedia
    {
        [Key]
        public int Id { get; set; }
        public string linkedin { get; set; }
        public string facebook { get; set; }
        public string twitter { get; set; }
        public string instagram { get; set; }
    }
}
