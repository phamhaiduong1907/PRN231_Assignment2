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
        [HttpGet]
        public async Task<IActionResult> GetOrderByInterval(DateTime? fromdate, DateTime? todate)
        {
            var orders = await _context.Orders.Include(o => o.OrderDetails).ToListAsync();
            if (fromdate != null && todate != null)
            {
                orders = orders.Where(o => o.OrderDate >= fromdate && o.OrderDate <= todate).ToList();
            }
            var result = orders.Select(o => new
            {
                OrderId = o.OrderId,
                CustomerId = o.CustomerId,
                EmployeeId = o.EmployeeId,
                OrderDate = o.OrderDate,
                OrderDetails = o.OrderDetails.Select( od => new
                {
                    ProductId = od.ProductId,
                    Quantity = od.Quantity,
                    UnitPrice = od.UnitPrice
                })
            }).ToList();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder()
        {
            return Ok();
        }
    }
}
