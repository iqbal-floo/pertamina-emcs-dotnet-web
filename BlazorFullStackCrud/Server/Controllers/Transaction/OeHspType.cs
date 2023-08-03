using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OeHspTypeController : ControllerBase
    {
        private readonly TransactionContext _context;

        public OeHspTypeController(TransactionContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<OeHspType>>> GetList()
        {
            var responses = await _context.OeHspTypes.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OeHspType>> GetSingle(int id)
        {
            var response = await _context.OeHspTypes
                .FirstOrDefaultAsync(h => h.OeHspTypeId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<OeHspType>>> CreateData(OeHspType formData)
        {
            _context.OeHspTypes.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<OeHspType>>> UpdateData(OeHspType formData, int id)
        {
            var dbData = await _context.OeHspTypes
                .FirstOrDefaultAsync(sh => sh.OeHspTypeId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.OeHspTypeId = formData.OeHspTypeId;
            dbData.OeId = formData.OeId;
            dbData.JobsName = formData.JobsName;
            dbData.PriceMaterial = formData.PriceMaterial;
            dbData.PriceService = formData.PriceService;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OeHspType>>> DeleteData(int id)
        {
            var dbData = await _context.OeHspTypes
                .FirstOrDefaultAsync(sh => sh.OeHspTypeId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.OeHspTypes.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<OeHspType>> GetDbData()
        {
            return await _context.OeHspTypes.ToListAsync();
        }

        #endregion
    }
}
