namespace OrderService
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateOnly CreationDate { get; set; }
        public bool IsDelivered { get; set; }
    }
}