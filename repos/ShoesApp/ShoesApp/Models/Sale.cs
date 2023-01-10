namespace ShoesApp.Models
{
    public class Sale
    {
        public int id { get; set; }
        public string userId { get; set; }
        public double totalAmt { get; set; }
        public DateTime dateOfPurchase { get; set; }
        
    }
}
