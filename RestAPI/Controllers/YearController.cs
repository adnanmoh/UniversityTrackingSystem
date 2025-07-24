using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class YearController : BaseController
    {
        public YearController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Year>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetYears()
        {
            var obj = await repositoryManager.YearRepository.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<YearVM>>(obj));
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(Year))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetYearById(int id)
        {
            if (!await repositoryManager.YearRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.YearRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<YearVM>(obj));
        }
    }
}
