using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HspTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public HspTypeController(DataContext context)
        {
            _context = context;
        }
        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<HspType>>> GetList()
        {
            var responses = await _context.HspTypes.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HspType>> GetSingle(int id)
        {
            var response = await _context.HspTypes
                .FirstOrDefaultAsync(h => h.HspTypeId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<HspType>>> CreateData(HspType formData)
        {
            _context.HspTypes.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<HspType>>> UpdateData(HspType formData, int id)
        {
            var dbData = await _context.HspTypes
                .FirstOrDefaultAsync(sh => sh.HspTypeId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.HspTypeId = formData.HspTypeId;
            dbData.Name = formData.Name;
            dbData.IsLockEdit = formData.IsLockEdit;
            dbData.IsPublish = formData.IsPublish;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<HspType>>> DeleteData(int id)
        {
            var dbData = await _context.HspTypes
                .FirstOrDefaultAsync(sh => sh.HspTypeId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.HspTypes.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<HspType>> GetDbData()
        {
            return await _context.HspTypes.ToListAsync();
        }

        #endregion
    }
}
