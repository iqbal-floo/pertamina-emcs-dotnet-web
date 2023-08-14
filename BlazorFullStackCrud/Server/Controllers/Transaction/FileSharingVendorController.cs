using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileSharingVendorController : ControllerBase
    {
        private readonly TransactionContext _context;

        public FileSharingVendorController(TransactionContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<TrFileSharingVendor>>> GetList()
        {
            var responses = await _context.TrFileSharingVendors.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrFileSharingVendor>> GetSingle(int id)
        {
            var response = await _context.TrFileSharingVendors
                .FirstOrDefaultAsync(h => h.FileSharingVendorId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<TrFileSharingVendor>>> CreateData(TrFileSharingVendor formData)
        {
            _context.TrFileSharingVendors.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TrFileSharingVendor>>> UpdateData(TrFileSharingVendor formData, int id)
        {
            var dbData = await _context.TrFileSharingVendors
                .FirstOrDefaultAsync(sh => sh.FileSharingVendorId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.FileSharingVendorId = formData.FileSharingVendorId;
            dbData.Name = formData.Name;
            dbData.Directory = formData.Directory;
            dbData.IsShow = formData.IsShow;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TrFileSharingVendor>>> DeleteData(int id)
        {
            var dbData = await _context.TrFileSharingVendors
                .FirstOrDefaultAsync(sh => sh.FileSharingVendorId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.TrFileSharingVendors.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<TrFileSharingVendor>> GetDbData()
        {
            return await _context.TrFileSharingVendors.ToListAsync();
        }
        #endregion
    }
}
