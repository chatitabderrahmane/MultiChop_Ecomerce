namespace E_comerce_project.Models.ViewsModel
{
    public class homeVM
    {
        
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public Newsletter Newsletter { get; set; }
        public List<SocialMedia> SocialMedia { get; set; }
        public List<SocieteInfos> SocieteInfos { get; set; }
        public Contact Contacts { get; set; }
        public List<specification> specifications { get; set; }
        public RegisterVM RegisterVM { get; set; }
        public LoginVM LoginVM { get; set; }   
        public List<ShopingCart> ShopingCarts { get; set; }

       
        //Post Formulaire Qty
        public  ShopingCart ShopingCart { get; set; }




    }
}
