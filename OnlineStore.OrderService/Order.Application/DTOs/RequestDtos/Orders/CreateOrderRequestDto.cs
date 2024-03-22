namespace Order.Application.DTOs.RequestDtos.Orders
{
    public class CreateOrderRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
        public string Comment { get; set; }
        public List<string> ProductIds { get; set; }
    }
}