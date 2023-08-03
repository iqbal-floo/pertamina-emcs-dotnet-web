using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OeJobsTypeController : ControllerBase
    {
        private readonly TransactionContext _context;

        public OeJobsTypeController(TransactionContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<OeJobsType>>> GetList()
        {
            var responses = await _context.OeJobsTypes.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OeJobsType>> GetSingle(int id)
        {
            var response = await _context.OeJobsTypes
                .FirstOrDefaultAsync(h => h.OeJobsTypeId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<OeJobsType>>> CreateData(OeJobsType formData)
        {
            _context.OeJobsTypes.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<OeJobsType>>> UpdateData(OeJobsType formData, int id)
        {
            var dbData = await _context.OeJobsTypes
                .FirstOrDefaultAsync(sh => sh.OeJobsTypeId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.OeJobsTypeId = formData.OeJobsTypeId;
            dbData.Name = formData.Name;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OeJobsType>>> DeleteData(int id)
        {
            var dbData = await _context.OeJobsTypes
                .FirstOrDefaultAsync(sh => sh.OeJobsTypeId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.OeJobsTypes.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<OeJobsType>> GetDbData()
        {
            return await _context.OeJobsTypes.ToListAsync();
        }

        #endregion
    }
}
