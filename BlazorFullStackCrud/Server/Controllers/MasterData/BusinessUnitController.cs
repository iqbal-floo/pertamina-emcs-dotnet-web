using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly DataContext _context;

        public BusinessUnitController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<BusinessUnit>>> GetList()
        {
            var businessUnit = await _context.BusinessUnits.ToListAsync();
            return Ok(businessUnit);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessUnit>> GetSingle(int id)
        {
            var response = await _context.BusinessUnits
                .FirstOrDefaultAsync(h => h.BusinessUnitId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<BusinessUnit>>> CreateData(BusinessUnit formData)
        {
            _context.BusinessUnits.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<BusinessUnit>>> UpdateData(BusinessUnit formData, int id)
        {
            var dbData = await _context.BusinessUnits
                .FirstOrDefaultAsync(sh => sh.BusinessUnitId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.BusinessUnitId = formData.BusinessUnitId;
            dbData.BusinessUnitCode = formData.BusinessUnitCode;
            dbData.BusinessUnitName = formData.BusinessUnitName;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<BusinessUnit>>> DeleteData(int id)
        {
            var dbData = await _context.BusinessUnits
                .FirstOrDefaultAsync(sh => sh.BusinessUnitId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.BusinessUnits.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<BusinessUnit>> GetDbData()
        {
            return await _context.BusinessUnits.ToListAsync();
        }

        #endregion
    }
}
