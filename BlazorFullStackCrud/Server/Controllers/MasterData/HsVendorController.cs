using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HsVendorController : ControllerBase
    {
        private readonly DataContext _context;

        public HsVendorController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<HsVendor>>> GetList()
        {
            var responses = await _context.HsVendors.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HsVendor>> GetSingle(int id)
        {
            var response = await _context.HsVendors
                .FirstOrDefaultAsync(h => h.HsVendorId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<HsVendor>>> CreateData(HsVendor formData)
        {
            _context.HsVendors.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<HsVendor>>> UpdateData(HsVendor formData, int id)
        {
            var dbData = await _context.HsVendors
                .FirstOrDefaultAsync(sh => sh.HsVendorId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.HsVendorId = formData.HsVendorId;
            dbData.MaterialCategoryId = formData.MaterialCategoryId;
            dbData.MaterialCategoryName = formData.MaterialCategoryName;
            dbData.MaterialSpecification = formData.MaterialSpecification;
            dbData.MaterialUom = formData.MaterialUom;
            dbData.MaterialPrice = formData.MaterialPrice;
            dbData.MaterialQuotationDate = formData.MaterialQuotationDate;
            dbData.MaterialBrand = formData.MaterialBrand;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<HsVendor>>> DeleteData(int id)
        {
            var dbData = await _context.HsVendors
                .FirstOrDefaultAsync(sh => sh.HsVendorId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.HsVendors.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<HsVendor>> GetDbData()
        {
            return await _context.HsVendors.ToListAsync();
        }

        #endregion
    }
}
