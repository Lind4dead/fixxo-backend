using fixxo_backend.Data;
using fixxo_backend.Models;
using fixxo_backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace fixxo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequest req)
        {
            try
            {
                var categoryEntity = new CategoryEntity { Name = req.Name };
                _context.Categoríes.Add(categoryEntity);
                await _context.SaveChangesAsync();

                var categoryResponse = new CategoryResponse { CategoryId = categoryEntity.Id, CategoryName = categoryEntity.Name };

                return new OkObjectResult(categoryResponse);
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
                var categories = new List<CategoryResponse>();
                foreach(var category in await _context.Categoríes.ToListAsync())
                    categories.Add(new CategoryResponse { CategoryId = category.Id, CategoryName = category.Name });

                return new OkObjectResult(categories);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new BadRequestResult();
        }
    }
}
