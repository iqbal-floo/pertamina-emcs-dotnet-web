using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskAndProfitController : ControllerBase
    {
        private readonly DataContext _context;

        public RiskAndProfitController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<RiskAndProfit>>> GetList()
        {
            var responses = await _context.RiskAndProfits.ToListAsync();
            return Ok(responses);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<RiskAndProfit>> GetSingle(int id)
        {
            var response = await _context.RiskAndProfits
                .FirstOrDefaultAsync(h => h.RiskAndProfitId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<RiskAndProfit>>> CreateData(RiskAndProfit formData)
        {
            _context.RiskAndProfits.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<RiskAndProfit>>> UpdateData(RiskAndProfit formData, int id)
        {
            var dbData = await _context.RiskAndProfits
                .FirstOrDefaultAsync(sh => sh.RiskAndProfitId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.RiskAndProfitId = formData.RiskAndProfitId;
            dbData.Percentage = formData.Percentage;
            dbData.MinimalThreshold = formData.MinimalThreshold;
            dbData.MaximalThreshold = formData.MaximalThreshold;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<RiskAndProfit>>> DeleteData(int id)
        {
            var dbData = await _context.RiskAndProfits
                .FirstOrDefaultAsync(sh => sh.RiskAndProfitId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.RiskAndProfits.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<RiskAndProfit>> GetDbData()
        {
            return await _context.RiskAndProfits.ToListAsync();
        }

        #endregion
    }
}
