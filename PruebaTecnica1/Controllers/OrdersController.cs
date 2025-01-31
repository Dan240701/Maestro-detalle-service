using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica1.Models.dto;

namespace PruebaTecnica1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public OrdersController(ApplicationDbContext context) //Inyeccion de dependencias
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        public async Task<ActionResult> PostOrder(orderDto orderDto)
        {
            var newOrder = new Order
            {
                CustomerName = orderDto.CustomerName,
                OrderDate = orderDto.OrderDate
            };

            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.Id }, newOrder);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(Guid id, orderDto orderDto)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            order.CustomerName = orderDto.CustomerName;
            order.OrderDate = orderDto.OrderDate;

            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}