using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LectureController : BaseController
    {
        public LectureController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Lecture>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLectures()
        {
            var Lectures = await repositoryManager.LectureRepository.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<LectureVM>>(Lectures));
        }


        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(Lecture))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetLectureById(int id)
        {
            if (!await repositoryManager.LectureRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.LectureRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<LectureVM>(obj));
        }
    }
}
