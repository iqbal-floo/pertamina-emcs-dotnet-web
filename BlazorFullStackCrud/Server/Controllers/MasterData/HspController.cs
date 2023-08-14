using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HspController : ControllerBase
    {
        private readonly DataContext _context;

        public HspController(DataContext context)
        {
            _context = context;
        }
        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<Hsp>>> GetList()
        {
            var responses = await _context.Hsps.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hsp>> GetSingle(int id)
        {
            var response = await _context.Hsps
                .FirstOrDefaultAsync(h => h.HspId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<Hsp>>> CreateData(Hsp formData)
        {
            formData.HspType = null;
            _context.Hsps.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Hsp>>> UpdateData(Hsp formData, int id)
        {
            var dbData = await _context.Hsps
                .FirstOrDefaultAsync(sh => sh.HspId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.HspId = formData.HspId;
            dbData.HspTypeId = formData.HspTypeId;
            dbData.HspItem = formData.HspItem;
            dbData.HspUom = formData.HspUom;
            dbData.RiskAndProfit = formData.RiskAndProfit;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Hsp>>> DeleteData(int id)
        {
            var dbData = await _context.Hsps
                .FirstOrDefaultAsync(sh => sh.HspId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.Hsps.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<Hsp>> GetDbData()
        {
            return await _context.Hsps.ToListAsync();
        }

        #endregion
    }
}
