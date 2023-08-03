using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HspItemController : ControllerBase
    {
        private readonly DataContext _context;

        public HspItemController(DataContext context)
        {
            _context = context;
        }
        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<HspItem>>> GetList()
        {
            var responses = await _context.HspItems.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HspItem>> GetSingle(int id)
        {
            var response = await _context.HspItems
                .FirstOrDefaultAsync(h => h.HspItemId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<HspItem>>> CreateData(HspItem formData)
        {
            _context.HspItems.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<HspItem>>> UpdateData(HspItem formData, int id)
        {
            var dbData = await _context.HspItems
                .FirstOrDefaultAsync(sh => sh.HspItemId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.HspItemId = formData.HspItemId;
            dbData.HspId = formData.HspId;
            dbData.HsId = formData.HsId;
            dbData.TableRef = formData.TableRef;
            dbData.Volume = formData.Volume;
            dbData.IsAllowEdit = formData.IsAllowEdit;
            dbData.EnableRiskAndProfit = formData.EnableRiskAndProfit;
            dbData.RiskAndProfit = formData.RiskAndProfit;
            dbData.Sort = formData.Sort;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<HspItem>>> DeleteData(int id)
        {
            var dbData = await _context.HspItems
                .FirstOrDefaultAsync(sh => sh.HspItemId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.HspItems.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<HspItem>> GetDbData()
        {
            return await _context.HspItems.ToListAsync();
        }

        #endregion
    }
}
