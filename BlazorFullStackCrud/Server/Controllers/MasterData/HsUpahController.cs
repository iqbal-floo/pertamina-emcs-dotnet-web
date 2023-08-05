using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HsUpahController : ControllerBase
    {
        private readonly DataContext _context;

        public HsUpahController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<HsUpah>>> GetList()
        {
            var responses = await _context.HsUpahs.ToListAsync();
            return Ok(responses);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<HsUpah>> GetSingle(int id)
        {
            var response = await _context.HsUpahs
                .FirstOrDefaultAsync(h => h.HsUpahId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<HsUpah>>> CreateData(HsUpah formData)
        {
            _context.HsUpahs.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<HsUpah>>> UpdateData(HsUpah formData, int id)
        {
            var dbData = await _context.HsUpahs
                .FirstOrDefaultAsync(sh => sh.HsUpahId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.HsUpahId = formData.HsUpahId;
            dbData.Description = formData.Description;
            dbData.Uom = formData.Uom;
            dbData.Price = formData.Price;
            dbData.Reference = formData.Reference;
            dbData.Tkdn = formData.Tkdn;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<HsUpah>>> DeleteData(int id)
        {
            var dbData = await _context.HsUpahs
                .FirstOrDefaultAsync(sh => sh.HsUpahId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.HsUpahs.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<HsUpah>> GetDbData()
        {
            return await _context.HsUpahs.ToListAsync();
        }

        #endregion
    }
}
