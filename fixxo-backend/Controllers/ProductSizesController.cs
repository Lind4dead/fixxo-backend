using fixxo_backend.Data;
using fixxo_backend.Models;
using fixxo_backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.Diagnostics;

namespace fixxo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSizesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductSizesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductSizeRequest req)
        {
            try
            {
                var _size = await _context.Sizes.FindAsync(req.ProductId);
                if(req.Size == _size.Size)
                {
                    return new BadRequestObjectResult("Size already exists on product");
                }
                

                var _productSize = new ProductSizeEntity
                {
                    Size = req.Size,
                    ProductId = req.ProductId
                };
                _context.Add(_productSize);
                await _context.SaveChangesAsync();

                return new OkResult();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var _sizes = new List<ProductSizeResponse>();

            foreach (var size in await _context.Sizes.Include(x => x.Product).ToListAsync())
                _sizes.Add(new ProductSizeResponse
                {
                    Id = size.Id,
                    Size = size.Size.GetDisplayName(),
                    ProductId = size.ProductId,
                    ProductName = size.Product.Name

                });


            return new OkObjectResult(_sizes);
        }
    }
}
