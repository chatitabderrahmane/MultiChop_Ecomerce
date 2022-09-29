using System.ComponentModel.DataAnnotations;

namespace E_comerce_project.Models
{
    public class SocieteInfos
    {
        [Key]
        public int Id { get; set; }
        public string MessageInfo { get; set; }
        public string Adress { get; set;}
        [EmailAddress]
        public string Email { get; set; }
        
        public string phone { get; set; }
    }
}
