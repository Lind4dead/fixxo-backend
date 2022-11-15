using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fixxo_backend.Data;
using Microsoft.EntityFrameworkCore;
using fixxo_backend.Models;
using fixxo_backend.Models.Entities;
using fixxo_backend.Migrations;

namespace fixxo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderProductController(DataContext context)
        {
            _context = context;
        }

  
        [HttpPost]
        public async Task<IActionResult> Create(OrderProductEntityRequest model)
        {
            if (ModelState.IsValid)
            {
                var orderEntity = await _context.Orders.FindAsync(model.OrderId);
                var productEntity = await _context.Products.FindAsync(model.ProductId);
                if (orderEntity != null)
                {
                    var orderProductEntity = new OrderProductEntityResponse
                    {
                        OrderId = orderEntity.Id,
                        ProductId = productEntity.Id,
                        Price = model.Price,
                        Total = model.Total
                    };


                 

                     _context.Add(orderProductEntity);
                    await _context.SaveChangesAsync();
                    return new OkObjectResult(new OrderProductEntityResponse
                    {
                        Id = orderProductEntity.Id,
                        OrderId = orderProductEntity.OrderId,
                        ProductId = orderProductEntity.ProductId,
                        Price = orderProductEntity.Price,
                        Total = orderProductEntity.Total
                    });
                }
                else
                {
                    return new BadRequestObjectResult(new { error = 400, message = "incorrect order Product type" });
                }
            }

            return new BadRequestResult();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderProductEntityResponse model)
        {
            if (id != model.Id)
                return new BadRequestResult();

            if (ModelState.IsValid)
            {
                var orderProductEntity = await _context.OrderProduct.FindAsync(model.Id);
               
                if (orderProductEntity != null)
                {
                    var orderEntity = await _context.Orders.FindAsync(model.OrderId);
                    var productEntity = await _context.Products.FindAsync(model.ProductId);
                    if (orderEntity != null)
                    {
                        if (productEntity != null)
                         {
                            orderProductEntity.OrderId= orderEntity.Id;
                            orderProductEntity.ProductId= productEntity.Id;
                            orderProductEntity.Price = model.Price;
                            orderProductEntity.Total = model.Total;


                            _context.Entry(orderProductEntity).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            return new OkObjectResult(new OrderProductEntityResponse
                            {
                                Id = orderProductEntity.Id,
                                OrderId = orderProductEntity.OrderId,
                                ProductId = orderProductEntity.ProductId,
                                Price = orderProductEntity.Price,
                                Total = orderProductEntity.Total
                            });
                        }
                    }
                }
            }

            return new BadRequestResult();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var orderProductEntity = await _context.OrderProduct.FindAsync(id);
            if (orderProductEntity != null)
                return new OkObjectResult(new OrderProductEntityResponse
                {
                    Id = orderProductEntity.Id,
                    OrderId = orderProductEntity.OrderId,
                    ProductId = orderProductEntity.ProductId,
                    Price = orderProductEntity.Price,
                    Total = orderProductEntity.Total
                });

            return new NotFoundResult();
        }

    }
}
