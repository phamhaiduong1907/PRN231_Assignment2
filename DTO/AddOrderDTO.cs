namespace Assignment2.DTO
{
    public class AddOrderDTO
    {
        public string CustomerId { get; set; } = null!;
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }
}
