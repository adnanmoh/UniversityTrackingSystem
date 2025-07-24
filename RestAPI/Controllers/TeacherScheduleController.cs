using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TeacherScheduleController : BaseController
    {
        public TeacherScheduleController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TeacherSchedule>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeacherSchedules()
        {
            var obj = await repositoryManager.TeacherScheduleRepository.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<TeacherScheduleVM>>(obj));
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(TeacherSchedule))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeacherSchedulesById(int id)
        {
            if (!await repositoryManager.TeacherScheduleRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.TeacherScheduleRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<TeacherScheduleVM>(obj));
        }

        [HttpGet("[action]/{teacherID}")]
        [ProducesResponseType(200, Type = typeof(TeacherSchedule))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStudentSchedulesByTeacherIDInCurrentYear(int teacherID)
        {
            var obj = await repositoryManager.TeacherScheduleRepository.GetStudentSchedulesByTeacherIDInCurrentYear(teacherID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<TeacherScheduleVM>>(obj));
        }
    }
}
