using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly DataContext _context;

        public VendorController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<Vendor>>> GetList()
        {
            var responses = await _context.Vendors.ToListAsync();
            return Ok(responses);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetSingle(int id)
        {
            var response = await _context.Vendors
                .FirstOrDefaultAsync(h => h.VendorId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<Vendor>>> CreateData(Vendor formData)
        {
            _context.Vendors.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Vendor>>> UpdateData(Vendor formData, int id)
        {
            var dbData = await _context.Vendors
                .FirstOrDefaultAsync(sh => sh.VendorId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.VendorId = formData.VendorId;
            dbData.VendorName = formData.VendorName;
            dbData.LatestPrice = formData.LatestPrice;
            dbData.QuotationDate = formData.QuotationDate;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Vendor>>> DeleteData(int id)
        {
            var dbData = await _context.Vendors
                .FirstOrDefaultAsync(sh => sh.VendorId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.Vendors.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<Vendor>> GetDbData()
        {
            return await _context.Vendors.ToListAsync();
        }

        #endregion
    }
}
