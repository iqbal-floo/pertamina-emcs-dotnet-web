using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly DataContext _context;

        public SettingController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<Setting>>> GetList()
        {
            var responses = await _context.Settings.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Setting>> GetSingle(int id)
        {
            var response = await _context.Settings
                .FirstOrDefaultAsync(h => h.SettingId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<Setting>>> CreateData(Setting formData)
        {
            _context.Settings.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Setting>>> UpdateData(Setting formData, int id)
        {
            var dbData = await _context.Settings
                .FirstOrDefaultAsync(sh => sh.SettingId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.SettingId = formData.SettingId;
            dbData.SettingName = formData.SettingName;
            dbData.ValidDate = formData.ValidDate;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Setting>>> DeleteData(int id)
        {
            var dbData = await _context.Settings
                .FirstOrDefaultAsync(sh => sh.SettingId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.Settings.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<Setting>> GetDbData()
        {
            return await _context.Settings.ToListAsync();
        }

        #endregion
    }
}
