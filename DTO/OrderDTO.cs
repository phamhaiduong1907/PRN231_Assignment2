namespace Assignment2.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public string? OrderDate { get; set; }

        public string OrderDetails { get; set; }
    }
}
