using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HsTransportController : ControllerBase
    {
        private readonly DataContext _context;

        public HsTransportController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<HsTransport>>> GetList()
        {
            var responses = await _context.HsTransports.ToListAsync();
            return Ok(responses);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<HsTransport>> GetSingle(int id)
        {
            var response = await _context.HsTransports
                .FirstOrDefaultAsync(h => h.HsTransportId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<HsTransport>>> CreateData(HsTransport formData)
        {
            _context.HsTransports.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<HsTransport>>> UpdateData(HsTransport formData, int id)
        {
            var dbData = await _context.HsTransports
                .FirstOrDefaultAsync(sh => sh.HsTransportId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.HsTransportId = formData.HsTransportId;
            dbData.Description = formData.Description;
            dbData.Origin = formData.Origin;
            dbData.Destination = formData.Destination;
            dbData.Uom = formData.Uom;
            dbData.Price = formData.Price;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<HsTransport>>> DeleteData(int id)
        {
            var dbData = await _context.HsTransports
                .FirstOrDefaultAsync(sh => sh.HsTransportId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.HsTransports.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<HsTransport>> GetDbData()
        {
            return await _context.HsTransports.ToListAsync();
        }

        #endregion
    }
}
