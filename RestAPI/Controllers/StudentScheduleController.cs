using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.Repository;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentScheduleController : BaseController
    {
        public StudentScheduleController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StudentSchedule>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStudentSchedules()
        {
            var obj = await repositoryManager.StudentScheduleRepository.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<StudentScheduleVM>>(obj));
        }

        [HttpGet("[action]/{groupID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StudentSchedule>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStudentSchedulesByGroupIDInCurrentYear(int groupID)
        {
            var obj = await repositoryManager.StudentScheduleRepository.GetStudentSchedulesByGroupIDInCurrentYear(groupID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<StudentScheduleVM>>(obj));
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(StudentSchedule))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStudentSchedulesById(int id)
        {
            if (!await repositoryManager.StudentScheduleRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.StudentScheduleRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<StudentScheduleVM>(obj));
        }
    }
}
