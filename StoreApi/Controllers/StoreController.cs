using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wkhtmltopdf.NetCore;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IGeneratePdf _generatePdf;
        private readonly StoreDbContext _context;

        public StoreController(IGeneratePdf generatePdf, StoreDbContext context)
        {
            _generatePdf = generatePdf;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllStores()
        {
            var stores = await _context.Stores.ToListAsync();
            return Ok(stores);
        }

        [HttpGet("{id}/pdf")]
        public async Task<IActionResult> GetStorePdf(int id)
        {
            var store = await _context.Stores
                .Include(s => s.Products)
                .FirstOrDefaultAsync(s => s.Id == id);
            var result = await _generatePdf.GetPdf(
                "Templates/StoreTemplate.cshtml", 
                store
                );
            return result;
        }

        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok("jalando");
        }
        
    }
}
