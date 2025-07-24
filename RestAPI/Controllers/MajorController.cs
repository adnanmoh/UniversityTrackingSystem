using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class MajorController : BaseController
    {
        public MajorController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Major>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMajors()
        {
            var Majors =await repositoryManager.MajorRepository.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<MajorVM>>(Majors));
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(Major))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetMajorById(int id)
        {
            if (!await repositoryManager.MajorRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.MajorRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<MajorVM>(obj));
        }


    }
}
