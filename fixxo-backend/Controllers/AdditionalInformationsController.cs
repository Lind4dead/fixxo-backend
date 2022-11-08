using fixxo_backend.Data;
using fixxo_backend.Models;
using fixxo_backend.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace fixxo_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalInformationsController : ControllerBase
    {
        private readonly DataContext _context;

        public AdditionalInformationsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdditionalInformationRequest req)
        {
            try
            {
                _context.Add(new AdditionalInformationEntity
                {
                    Data = req.Data,
                    ProductId = req.ProductId,
                    ClassificationId = req.ClassificationId
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
                var infos = new List<AdditionalInformationEntity>();
                foreach (var info in await _context.AdditionalInformations.ToListAsync())
                    infos.Add(info);

                return new OkObjectResult(infos);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return new BadRequestResult();
        }
    }
}
