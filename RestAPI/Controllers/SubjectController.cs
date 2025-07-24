using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class SubjectController : BaseController
    {
        public SubjectController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(Subject))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            if (!await repositoryManager.SubjectRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.SubjectRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<SubjectVM>(obj));
        }
    }
}
