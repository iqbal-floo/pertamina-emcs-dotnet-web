using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OeHspItemController : ControllerBase
    {
        private readonly TransactionContext _context;

        public OeHspItemController(TransactionContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<OeHspItem>>> GetList()
        {
            var responses = await _context.OeHspItems.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OeHspItem>> GetSingle(int id)
        {
            var response = await _context.OeHspItems
                .FirstOrDefaultAsync(h => h.OeHspItemId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<OeHspItem>>> CreateData(OeHspItem formData)
        {
            _context.OeHspItems.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<OeHspItem>>> UpdateData(OeHspItem formData, int id)
        {
            var dbData = await _context.OeHspItems
                .FirstOrDefaultAsync(sh => sh.OeHspItemId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.OeHspItemId = formData.OeHspItemId;
            dbData.OeHspId = formData.OeHspId;
            dbData.Volume = formData.Volume;
            dbData.ItemUom = formData.ItemUom;
            dbData.ItemName = formData.ItemName;
            dbData.ItemPrice = formData.ItemPrice;
            dbData.ItemPriceKoef = formData.ItemPriceKoef;
            dbData.PriceType = formData.PriceType;
            dbData.IsAllowEdit = formData.IsAllowEdit;
            dbData.EnableRiskAndProfitMat = formData.EnableRiskAndProfitMat;
            dbData.RiskAndProfitMat = formData.RiskAndProfitMat;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OeHspItem>>> DeleteData(int id)
        {
            var dbData = await _context.OeHspItems
                .FirstOrDefaultAsync(sh => sh.OeHspItemId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.OeHspItems.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<OeHspItem>> GetDbData()
        {
            return await _context.OeHspItems.ToListAsync();
        }

        #endregion
    }
}
