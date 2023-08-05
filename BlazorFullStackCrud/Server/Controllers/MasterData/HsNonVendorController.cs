using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HsNonVendorController : ControllerBase
    {
        private readonly DataContext _context;

        public HsNonVendorController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<HsNonVendor>>> GetList()
        {
            var responses = await _context.HsNonVendors.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HsNonVendor>> GetSingle(int id)
        {
            var response = await _context.HsNonVendors
                .FirstOrDefaultAsync(h => h.HsNonVendorId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<HsNonVendor>>> CreateData(HsNonVendor formData)
        {
            formData.MaterialCategory = null;
            _context.HsNonVendors.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<HsNonVendor>>> UpdateData(HsNonVendor formData, int id)
        {
            var dbData = await _context.HsNonVendors
                .FirstOrDefaultAsync(sh => sh.HsNonVendorId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.HsNonVendorId = formData.HsNonVendorId;
            dbData.Description = formData.Description;
            dbData.MaterialCategoryId = formData.MaterialCategoryId;
            dbData.Uom = formData.Uom;
            dbData.Price = formData.Price;
            dbData.Reference = formData.Reference;
            dbData.Tkdn = formData.Tkdn;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<HsNonVendor>>> DeleteData(int id)
        {
            var dbData = await _context.HsNonVendors
                .FirstOrDefaultAsync(sh => sh.HsNonVendorId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.HsNonVendors.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<HsNonVendor>> GetDbData()
        {
            return await _context.HsNonVendors.ToListAsync();
        }

        #endregion
    }
}
