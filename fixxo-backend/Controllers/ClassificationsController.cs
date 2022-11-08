using fixxo_backend.Data;
using fixxo_backend.Models;
using fixxo_backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace fixxo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationsController : ControllerBase
    {
        private readonly DataContext _context;

        public ClassificationsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClassificationRequest req)
        {
            try
            {
                _context.Add(new ClassificationEntity
                {
                    Name = req.Name
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
                var classes = new List<ClassificationEntity>();
                foreach (var _class in await _context.Classifications.ToListAsync())
                    classes.Add(_class);

                return new OkObjectResult(classes);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new BadRequestResult();
        }
    }
}
