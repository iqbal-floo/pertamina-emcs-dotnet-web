using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileSharingController : ControllerBase
    {
        private readonly TransactionContext _context;

        public FileSharingController(TransactionContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<TrFileSharing>>> GetList()
        {
            var responses = await _context.TrFileSharings.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrFileSharing>> GetSingle(int id)
        {
            var response = await _context.TrFileSharings
                .FirstOrDefaultAsync(h => h.FileSharingId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<TrFileSharing>>> CreateData(TrFileSharing formData)
        {
            _context.TrFileSharings.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TrFileSharing>>> UpdateData(TrFileSharing formData, int id)
        {
            var dbData = await _context.TrFileSharings
                .FirstOrDefaultAsync(sh => sh.FileSharingId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.FileSharingId = formData.FileSharingId;
            dbData.Name = formData.Name;
            dbData.Directory = formData.Directory;
            dbData.IsShow = formData.IsShow;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TrFileSharing>>> DeleteData(int id)
        {
            var dbData = await _context.TrFileSharings
                .FirstOrDefaultAsync(sh => sh.FileSharingId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.TrFileSharings.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<TrFileSharing>> GetDbData()
        {
            return await _context.TrFileSharings.ToListAsync();
        }
        #endregion
    }
}
