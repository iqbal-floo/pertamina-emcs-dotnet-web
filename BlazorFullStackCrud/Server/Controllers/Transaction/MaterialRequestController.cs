using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialRequestController : ControllerBase
    {
        private readonly TransactionContext _context;

        public MaterialRequestController(TransactionContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<MaterialRequest>>> GetList()
        {
            var responses = await _context.MaterialRequests.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialRequest>> GetSingle(int id)
        {
            var response = await _context.MaterialRequests
                .FirstOrDefaultAsync(h => h.MaterialRequestId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<MaterialRequest>>> CreateData(MaterialRequest formData)
        {
            formData.MaterialCategory = null;
            _context.MaterialRequests.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<MaterialRequest>>> UpdateData(MaterialRequest formData, int id)
        {
            var dbData = await _context.MaterialRequests
                .FirstOrDefaultAsync(sh => sh.MaterialRequestId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.MaterialRequestId = formData.MaterialRequestId;
            dbData.MaterialCategoryId = formData.MaterialCategoryId;
            dbData.Name = formData.Name;
            dbData.Specification = formData.Specification;
            dbData.Unit = formData.Unit;
            dbData.Status = formData.Status;
            dbData.ApprovedBy = formData.ApprovedBy;
            dbData.ApprovedByName = formData.ApprovedByName;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MaterialRequest>>> DeleteData(int id)
        {
            var dbData = await _context.MaterialRequests
                .FirstOrDefaultAsync(sh => sh.MaterialRequestId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.MaterialRequests.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<MaterialRequest>> GetDbData()
        {
            return await _context.MaterialRequests.ToListAsync();
        }

        #endregion
    }
}
