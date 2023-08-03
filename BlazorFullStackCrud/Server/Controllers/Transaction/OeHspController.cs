using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OeHspController : ControllerBase
    {
        private readonly TransactionContext _context;

        public OeHspController(TransactionContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<OeHsp>>> GetList()
        {
            var responses = await _context.OeHsps.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OeHsp>> GetSingle(int id)
        {
            var response = await _context.OeHsps
                .FirstOrDefaultAsync(h => h.OeHspId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<OeHsp>>> CreateData(OeHsp formData)
        {
            _context.OeHsps.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<OeHsp>>> UpdateData(OeHsp formData, int id)
        {
            var dbData = await _context.OeHsps
                .FirstOrDefaultAsync(sh => sh.OeHspId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.OeHspId = formData.OeHspId;
            dbData.OeHspTypeId = formData.OeHspTypeId;
            dbData.HspTypeId = formData.HspTypeId;
            dbData.HspId = formData.HspId;
            dbData.ItemHsp = formData.ItemHsp;
            dbData.Volume = formData.Volume;
            dbData.PriceUom = formData.PriceUom;
            dbData.PriceMaterial = formData.PriceMaterial;
            dbData.PriceService = formData.PriceService;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OeHsp>>> DeleteData(int id)
        {
            var dbData = await _context.OeHsps
                .FirstOrDefaultAsync(sh => sh.OeHspId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.OeHsps.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<OeHsp>> GetDbData()
        {
            return await _context.OeHsps.ToListAsync();
        }

        #endregion
    }
}
