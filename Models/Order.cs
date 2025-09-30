namespace TestMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public DateTime? Date { get; set; }

        // FK → User
        public int? IdClient { get; set; }
        public User Client { get; set; }
    }
}