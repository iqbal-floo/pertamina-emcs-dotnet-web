using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HsSewaController : ControllerBase
    {
        private readonly DataContext _context;

        public HsSewaController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<HsSewa>>> GetList()
        {
            var responses = await _context.HsSewas.ToListAsync();
            return Ok(responses);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<HsSewa>> GetSingle(int id)
        {
            var response = await _context.HsSewas
                .FirstOrDefaultAsync(h => h.HsSewaId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<HsSewa>>> CreateData(HsSewa formData)
        {
            _context.HsSewas.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<HsSewa>>> UpdateData(HsSewa formData, int id)
        {
            var dbData = await _context.HsSewas
                .FirstOrDefaultAsync(sh => sh.HsSewaId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.HsSewaId = formData.HsSewaId;
            dbData.Description = formData.Description;
            dbData.MaterialCategoryId = formData.MaterialCategoryId;
            dbData.Uom = formData.Uom;
            dbData.Price = formData.Price;
            dbData.Reference = formData.Reference;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<HsSewa>>> DeleteData(int id)
        {
            var dbData = await _context.HsSewas
                .FirstOrDefaultAsync(sh => sh.HsSewaId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.HsSewas.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<HsSewa>> GetDbData()
        {
            return await _context.HsSewas.ToListAsync();
        }

        #endregion

    }
}
