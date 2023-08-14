using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OeReviewerController : ControllerBase
    {
        private readonly TransactionContext _context;

        public OeReviewerController(TransactionContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<OeReviewer>>> GetList()
        {
            var responses = await _context.OeReviewers.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OeReviewer>> GetSingle(int id)
        {
            var response = await _context.OeReviewers
                .FirstOrDefaultAsync(h => h.OeReviewerId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<OeReviewer>>> CreateData(OeReviewer formData)
        {
            formData.Oe = null;
            _context.OeReviewers.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<OeReviewer>>> UpdateData(OeReviewer formData, int id)
        {
            var dbData = await _context.OeReviewers
                .FirstOrDefaultAsync(sh => sh.OeReviewerId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.OeReviewerId = formData.OeReviewerId;
            dbData.OeId = formData.OeId;
            dbData.ReviewerUserId = formData.ReviewerUserId;
            dbData.ReviewStatus= formData.ReviewStatus;
            dbData.ReviewDate = formData.ReviewDate;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OeReviewer>>> DeleteData(int id)
        {
            var dbData = await _context.OeReviewers
                .FirstOrDefaultAsync(sh => sh.OeReviewerId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.OeReviewers.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<OeReviewer>> GetDbData()
        {
            return await _context.OeReviewers.ToListAsync();
        }

        #endregion
    }
}
