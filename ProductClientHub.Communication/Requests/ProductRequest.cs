namespace ProductClientHub.Communication.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
