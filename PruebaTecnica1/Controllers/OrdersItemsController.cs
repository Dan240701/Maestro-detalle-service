using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica1.Models.dto;

namespace PruebaTecnica1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersItemsController : ControllerBase
    {
        //atributo
        private readonly ApplicationDbContext _context;

        //inyeccion de dependencias
        public OrdersItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //metodo para obtener todos los items de una orden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> PostOrderItems(OrdenItemsDto itemsDto)
        {
            if (itemsDto == null)
            {
                return BadRequest();
            }

            // Verificar si el pedido existe
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == itemsDto.OrderId);
            if (order == null)
            {
                return NotFound($"Order with Id {itemsDto.OrderId} not found.");
            }
            // Mapear DTO a entidad
            var newOrderItem = new OrderItem
            {
                OrderId = itemsDto.OrderId,
                ProductName = itemsDto.ProductName,
                Quantity = itemsDto.Quantity,
                Price = itemsDto.Price,
                Order = order
            };


            _context.OrderItems.Add(newOrderItem);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderItems), new { id = newOrderItem.Id }, newOrderItem);
        }
    }
}
