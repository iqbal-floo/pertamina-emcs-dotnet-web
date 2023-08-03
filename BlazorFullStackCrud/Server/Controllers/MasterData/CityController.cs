using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly DataContext _context;

        public CityController(DataContext context)
        {
            _context = context;
        }

        /* CRUD BASE */
        #region

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetList()
        {
            var responses = await _context.Cities.ToListAsync();
            return Ok(responses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetSingle(int id)
        {
            var response = await _context.Cities
                .FirstOrDefaultAsync(h => h.CityId == id);
            if (response == null)
            {
                return NotFound("Sorry, data not found");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<City>>> CreateData(City formData)
        {
            _context.Cities.Add(formData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<City>>> UpdateData(City formData, int id)
        {
            var dbData = await _context.Cities
                .FirstOrDefaultAsync(sh => sh.CityId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            dbData.CityId = formData.CityId;
            dbData.CityName = formData.CityName;
            dbData.ProvinceId = formData.ProvinceId;
            dbData.ProvinceName = formData.ProvinceName;
            dbData.KoefKemahalanMaterial = formData.KoefKemahalanMaterial;
            dbData.KoefKemahalanService = formData.KoefKemahalanService;
            dbData.Notes = formData.Notes;

            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<City>>> DeleteData(int id)
        {
            var dbData = await _context.Cities
                .FirstOrDefaultAsync(sh => sh.CityId == id);
            if (dbData == null)
                return NotFound("Sorry, data not found");

            _context.Cities.Remove(dbData);
            await _context.SaveChangesAsync();

            return Ok(await GetDbData());
        }

        private async Task<List<City>> GetDbData()
        {
            return await _context.Cities.ToListAsync();
        }
        #endregion
    }
}
