using Assignment2.DTO;
using Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Assignment2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        NORTHWNDContext _context;
        public OrdersController(NORTHWNDContext context)
        {
            _context = context;
        }
        [HttpGet("{fromdate}/{todate}")]
        [Produces("text/csv")]
        public async Task<IActionResult> GetOrderByInterval(DateTime fromdate, DateTime todate)
        {
            List<Order> orders = await _context.Orders.Include(o => o.OrderDetails).Where(o => o.OrderDate >= fromdate && o.OrderDate <= todate).ToListAsync();
            List<OrderDTO> orderDTOs = orders.Select(o => new OrderDTO
            {
                OrderId = o.OrderId,
                CustomerId = o.CustomerId,
                EmployeeId = o.EmployeeId,
                OrderDate = o.OrderDate.Value.ToShortDateString(),
                OrderDetails = string.Join(";",o.OrderDetails.Select(od => string.Join(";", od.ProductId, od.Quantity, od.UnitPrice)))
            }).ToList();
            return Ok(orderDTOs);
        }
    }
}
