namespace ProductClientHub.Communication.Responses
{
    public class ClientResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<ProductShortResponse> Products { get; set; } = [];
    }
}
