using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskAndProfitMatController : ControllerBase
    {
        private readonly DataContext _context;

        public RiskAndProfitMatController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<RiskAndProfitMat>>> GetList()
        {
            var responses = await _context.RiskAndProfitMats.ToListAsync();
            return Ok(responses);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<RiskAndProfitMat>> GetSingle(int id)
        {
            var response = await _context.RiskAndProfitMats
                .FirstOrDefaultAsync(h => h.RiskAndProfitMatId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<RiskAndProfitMat>>> CreateData(RiskAndProfitMat formData)
        {
            _context.RiskAndProfitMats.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<RiskAndProfitMat>>> UpdateData(RiskAndProfitMat formData, int id)
        {
            var dbData = await _context.RiskAndProfitMats
                .FirstOrDefaultAsync(sh => sh.RiskAndProfitMatId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.RiskAndProfitMatId = formData.RiskAndProfitMatId;
            dbData.Percentage = formData.Percentage;
            dbData.MinimalThreshold = formData.MinimalThreshold;
            dbData.MaximalThreshold = formData.MaximalThreshold;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<RiskAndProfitMat>>> DeleteData(int id)
        {
            var dbData = await _context.RiskAndProfitMats
                .FirstOrDefaultAsync(sh => sh.RiskAndProfitMatId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.RiskAndProfitMats.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<RiskAndProfitMat>> GetDbData()
        {
            return await _context.RiskAndProfitMats.ToListAsync();
        }

        #endregion
    }
}
