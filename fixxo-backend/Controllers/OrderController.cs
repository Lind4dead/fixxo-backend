using fixxo_backend.Data;
using fixxo_backend.Models.Entities;
using fixxo_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace fixxo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = new List<OrderResponse>();
                foreach (var order in await _context.Orders.ToListAsync())
                    orders.Add(new OrderResponse { Id= order.Id, Email = order.Email , ProductId = order.ProductId , Address =order.Address , CreatedAt = order.CreatedAt });

                return new OkObjectResult(orders);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new BadRequestResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderRequest req)
        {
            try
            {
                var orderEntity = await _context.Orders.FirstOrDefaultAsync(x => x.ProductId == req.ProductId);
                if (orderEntity == null)
                    return new BadRequestObjectResult("Product not found");

                _context.Add(new OrderEntity
                {
                    ProductId = req.ProductId,
                    Email = req.Email,
                    Address = req.Address,
                    CreatedAt = req.CreatedAt

                 });
                await _context.SaveChangesAsync();

                return new OkResult();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new BadRequestResult();
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderRequest req)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                order.ProductId = req.ProductId;
                order.Email = req.Email;
                order.Address = req.Address;
                order.CreatedAt = req.CreatedAt;

                _context.Entry(order).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var orderTemp= await _context.Orders.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == order.Id);
                return new OkObjectResult(new OrderResponse
                {   Id = order.Id,
                    ProductId = order.ProductId,
                    Email = order.Email,
                    Address = order.Address,
                    CreatedAt = order.CreatedAt
                });


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new NotFoundResult();
        }

    }
}
