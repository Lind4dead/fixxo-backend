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
    public class ProductColorsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductColorsController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductColorRequest req)
        {
            try
            {
                _context.Add(new ProductColorEntity
                {
                    Color = req.Color,
                    ImgUrl = req.ImgUrl,
                    ProductId = req.ProductId
                });
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
            var _sizes = new List<ProductColorResponse>();

            foreach (var color in await _context.Colors.Include(x => x.Product).ToListAsync())
                _sizes.Add(new ProductColorResponse
                {
                    Id = color.Id,
                    ColorName = color.Color.GetDisplayName(),
                    ImgUrl = color.ImgUrl,
                    ProductId = color.ProductId,
                    ProductName = color.Product.Name

                });


            return new OkObjectResult(_sizes);
        }
    }
}
