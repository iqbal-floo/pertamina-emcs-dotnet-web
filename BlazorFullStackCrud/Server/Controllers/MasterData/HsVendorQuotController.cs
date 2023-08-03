using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HsVendorQuotController : ControllerBase
    {
        private readonly DataContext _context;

        public HsVendorQuotController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<HsVendorQuot>>> GetList()
        {
            var responses = await _context.HsVendorQuots.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HsVendorQuot>> GetSingle(int id)
        {
            var response = await _context.HsVendorQuots
                .FirstOrDefaultAsync(h => h.HsVendorQuotId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<HsVendorQuot>>> CreateData(HsVendorQuot formData)
        {
            _context.HsVendorQuots.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<HsVendorQuot>>> UpdateData(HsVendorQuot formData, int id)
        {
            var dbData = await _context.HsVendorQuots
                .FirstOrDefaultAsync(sh => sh.HsVendorQuotId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.HsVendorQuotId = formData.HsVendorQuotId;
            dbData.MaterialId = formData.MaterialId;
            dbData.QuotPrice = formData.QuotPrice;
            dbData.QuotDate = formData.QuotDate;
            dbData.HsVendorId = formData.HsVendorId;
            dbData.FileId = formData.FileId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<HsVendorQuot>>> DeleteData(int id)
        {
            var dbData = await _context.HsVendorQuots
                .FirstOrDefaultAsync(sh => sh.HsVendorQuotId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.HsVendorQuots.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<HsVendorQuot>> GetDbData()
        {
            return await _context.HsVendorQuots.ToListAsync();
        }

        #endregion
    }
}
