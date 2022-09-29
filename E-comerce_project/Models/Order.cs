namespace E_comerce_project.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Statut { get; set; } = "en cours";   
        public string ListItems { get; set; } 
        public double Total { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }    

        public DateTime DateOrdered { get; set; }


    }
}
