using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly TransactionContext _context;

        public FileController(TransactionContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<TrFile>>> GetList()
        {
            var responses = await _context.TrFiles.ToListAsync();
            return Ok(responses);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TrFile>> GetSingle(int id)
        {
            var response = await _context.TrFiles
                .FirstOrDefaultAsync(h => h.FileId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<TrFile>>> CreateData(TrFile formData)
        {
            _context.TrFiles.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TrFile>>> UpdateData(TrFile formData, int id)
        {
            var dbData = await _context.TrFiles
                .FirstOrDefaultAsync(sh => sh.FileId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.FileId = formData.FileId;
            dbData.FileName = formData.FileName;
            dbData.FileDirectory = formData.FileDirectory;
            dbData.FileRelationTable = formData.FileRelationTable;
            dbData.FileDate = formData.FileDate;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TrFile>>> DeleteData(int id)
        {
            var dbData = await _context.TrFiles
                .FirstOrDefaultAsync(sh => sh.FileId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.TrFiles.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<TrFile>> GetDbData()
        {
            return await _context.TrFiles.ToListAsync();
        }

        #endregion
    }
}
