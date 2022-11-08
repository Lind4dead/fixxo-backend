using fixxo_backend.Data;
using fixxo_backend.Models;
using fixxo_backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

using System.Diagnostics;

namespace fixxo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductRequest req)
        {
            try
            {
                var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Id == req.CategoryId);
                if (categoryEntity == null)
                    return new BadRequestObjectResult("Category not found");

                _context.Add(new ProductEntity
                {
                    Name = req.Name,
                    Price = req.Price,
                    Description = req.Description,
                    CategoryId = req.CategoryId


      




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
            try
            {
                var products = new List<ProductResponse>();
                foreach (var product in await _context.Products.Include(x => x.Category).Include(x => x.Colors).ToListAsync())
                {

                    var _color = await _context.Colors.FirstOrDefaultAsync(x => x.ProductId == product.Id);
                    if(_color != null)
                    {

                    products.Add(new ProductResponse
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        CategoryId = product.CategoryId,
                        CategoryName = product.Category.Name,
                        ImgUrl = _color.ImgUrl




                    });
                    }
                }

                return new OkObjectResult(products);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new BadRequestResult();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var _colors = new List<ProductSingleColorResponse>();
                foreach(var color in await _context.Colors.Include(x => x.Product).ToListAsync())
                {
                    if(color.ProductId == id)
                    {
                        _colors.Add(new ProductSingleColorResponse
                        {                          
                            ColorName = color.Color.GetDisplayName(),
                            ImgUrl = color.ImgUrl 
                        });
                    }
                }

                var _sizes = new List<ProductSingleSizeResponse>();
                foreach (var size in await _context.Sizes.Include(x => x.Product).ToListAsync())
                {
                    if (size.ProductId == id)
                    {
                        _sizes.Add(new ProductSingleSizeResponse
                        {
                            Size = size.Size.GetDisplayName()
                        });
                    }
                }

                var _info = new List<AdditionalInformationResponse>();
                foreach(var info in await _context.AdditionalInformations.Include(x => x.Classification).ToListAsync())
                {
                    if(info.ProductId == id)
                    {
                        _info.Add(new AdditionalInformationResponse
                        {
                            Data = info.Data,
                            Classification = info.Classification.Name
                        });
                    }
                }

                var product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
                if (product != null)
                    return new OkObjectResult(new ProductSingleResponse
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Description = product.Description,
                        Colors = _colors,
                        Sizes = _sizes,
                        AdditionalInformationResponses = _info,
                        CategoryId = product.CategoryId,
                        CategoryName = product.Category.Name
                    });
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new NotFoundResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductRequest req)
        {
            try
            {
                var _product = await _context.Products.FindAsync(id);
                _product.Name = req.Name;
                _product.Price = req.Price;
                _product.Description = req.Description;
                _product.CategoryId = req.CategoryId;

                _context.Entry(_product).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == _product.Id);
                return new OkObjectResult(new ProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.Name
                });


            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new NotFoundResult();
        }
    }
}
