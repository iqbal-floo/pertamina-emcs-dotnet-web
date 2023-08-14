using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HsNonVendorCityController : ControllerBase
    {
        private readonly DataContext _context;

        public HsNonVendorCityController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<HsNonVendorCity>>> GetList()
        {
            var responses = await _context.HsNonVendorCities.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HsNonVendorCity>> GetSingle(int id)
        {
            var response = await _context.HsNonVendorCities
                .FirstOrDefaultAsync(h => h.HsNonVendorCityId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<HsNonVendorCity>>> CreateData(HsNonVendorCity formData)
        {
            formData.HsNonVendor = null;
            formData.City = null;
            _context.HsNonVendorCities.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<HsNonVendorCity>>> UpdateData(HsNonVendorCity formData, int id)
        {
            var dbData = await _context.HsNonVendorCities
                .FirstOrDefaultAsync(sh => sh.HsNonVendorCityId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.HsNonVendorCityId = formData.HsNonVendorCityId;
            dbData.HsNonVendorId = formData.HsNonVendorId;
            dbData.CityId = formData.CityId;
            dbData.Price = formData.Price;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<HsNonVendorCity>>> DeleteData(int id)
        {
            var dbData = await _context.HsNonVendorCities
                .FirstOrDefaultAsync(sh => sh.HsNonVendorCityId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.HsNonVendorCities.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<HsNonVendorCity>> GetDbData()
        {
            return await _context.HsNonVendorCities.ToListAsync();
        }

        #endregion
    }
}
