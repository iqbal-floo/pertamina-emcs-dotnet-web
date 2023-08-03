using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OeController : ControllerBase
    {
        private readonly TransactionContext _context;

        public OeController(TransactionContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<Oe>>> GetList()
        {
            var responses = await _context.Oes.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Oe>> GetSingle(int id)
        {
            var response = await _context.Oes
                .FirstOrDefaultAsync(h => h.OeId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<Oe>>> CreateData(Oe formData)
        {
            _context.Oes.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Oe>>> UpdateData(Oe formData, int id)
        {
            var dbData = await _context.Oes
                .FirstOrDefaultAsync(sh => sh.OeId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.OeId = formData.OeId;
            dbData.OeTitle = formData.OeTitle;
            dbData.CityId = formData.CityId;
            dbData.BusinessUnitId = formData.BusinessUnitId;
            dbData.MataAnggaran = formData.MataAnggaran;
            dbData.OeType = formData.OeType;
            dbData.OeJobsTypeId = formData.OeJobsTypeId;
            dbData.OeWo = formData.OeWo;
            dbData.OeVersion = formData.OeVersion;
            dbData.OeRefId = formData.OeRefId;
            dbData.OeDate = formData.OeDate;
            dbData.OePeriodYear = formData.OePeriodYear;
            dbData.OePeriodMonth = formData.OePeriodMonth;
            dbData.OePeriodDay = formData.OePeriodDay;
            dbData.SubmittedAt = formData.SubmittedAt;
            dbData.SubmittedById = formData.SubmittedById;
            dbData.SubmittedByName = formData.SubmittedByName;
            dbData.ApproveStatus = formData.ApproveStatus;
            dbData.ApproveNotes = formData.ApproveNotes;
            dbData.ApprovedAt = formData.ApprovedAt;
            dbData.ApprovedById = formData.ApprovedById;
            dbData.ApprovedByName = formData.ApprovedByName;
            dbData.SetAsTemplates= formData.SetAsTemplates;
            dbData.OeStatus = formData.OeStatus;
            dbData.OeStatusValidation = formData.OeStatusValidation;
            dbData.RiskAndProfit = formData.RiskAndProfit;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Oe>>> DeleteData(int id)
        {
            var dbData = await _context.Oes
                .FirstOrDefaultAsync(sh => sh.OeId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.Oes.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<Oe>> GetDbData()
        {
            return await _context.Oes.ToListAsync();
        }

        #endregion
    }
}
