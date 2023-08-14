using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OeChartConfigController : ControllerBase
    {
        private readonly TransactionContext _context;

        public OeChartConfigController(TransactionContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<OeChartConfig>>> GetList()
        {
            var responses = await _context.OeChartConfigs.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OeChartConfig>> GetSingle(int id)
        {
            var response = await _context.OeChartConfigs
                .FirstOrDefaultAsync(h => h.OeChartConfigId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<OeChartConfig>>> CreateData(OeChartConfig formData)
        {
            formData.OeHsp = null;
            _context.OeChartConfigs.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<OeChartConfig>>> UpdateData(OeChartConfig formData, int id)
        {
            var dbData = await _context.OeChartConfigs
                .FirstOrDefaultAsync(sh => sh.OeChartConfigId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.OeChartConfigId = formData.OeChartConfigId;
            dbData.OeHspId = formData.OeHspId;
            dbData.StartDate = formData.StartDate;
            dbData.Predecessor = formData.Predecessor;
            dbData.PercentageCompletion = formData.PercentageCompletion;
            dbData.IsOnCriticalPath = formData.IsOnCriticalPath;
            dbData.Notes = formData.Notes ;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OeChartConfig>>> DeleteData(int id)
        {
            var dbData = await _context.OeChartConfigs
                .FirstOrDefaultAsync(sh => sh.OeChartConfigId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.OeChartConfigs.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<OeChartConfig>> GetDbData()
        {
            return await _context.OeChartConfigs.ToListAsync();
        }

        #endregion
    }
}
