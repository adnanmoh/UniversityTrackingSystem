using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LectureForSubjectController : BaseController
    {
        public LectureForSubjectController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]/{subjectID}")]
        [ProducesResponseType(200, Type = typeof(LectureForSubject))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllLectureForOneSubject(int subjectID)
        {

            var obj = await repositoryManager.LectureForSubjectRepository.GetAllLectureForOneSubject(subjectID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<List<LectureForSubjectVM>>(obj));
        }
    }
}
