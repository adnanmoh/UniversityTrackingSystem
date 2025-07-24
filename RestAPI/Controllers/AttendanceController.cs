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
    public class AttendanceController : BaseController
    {
        public AttendanceController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]/{studentID}+{subjectID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Attendance>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAllAttendancesForStudentInSubject(int studentID , int subjectID)
        {
            var Attendances =await repositoryManager.AttendanceRepository.GetAllAttendancesForStudentInSubject(studentID, subjectID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<AttendanceVM>>(Attendances));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<string> AddAttendance([FromBody] AttendanceVM objVM)
        {
            try
            {
                var obj = mapper.Map<Attendance>(objVM);

                var res = await repositoryManager.AttendanceRepository.Add(obj);

                return res != null ? "success" : "error";

            }
            catch
            {

                return "error";
            }
        }

        [HttpPut("[action]/{AttendanceID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditeAttendance(int AttendanceID, [FromBody] AttendanceVM objVM)
        {
            try
            {
                var obj = mapper.Map<Attendance>(objVM);
                if (obj == null)
                {
                    return BadRequest(ModelState);
                }
                if (AttendanceID != obj.AttendanceId)
                {
                    return BadRequest(ModelState);
                }
                var existingObj = await repositoryManager.AttendanceRepository.GetObjById(AttendanceID);
                if (existingObj == null)
                {
                    return NotFound();
                }
                mapper.Map(objVM, existingObj);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var res = repositoryManager.AttendanceRepository.Edit(existingObj);

                if (res == null)
                {
                    ModelState.AddModelError("", "something went wrong");
                    return StatusCode(500, ModelState);
                }
                return Ok("success");
            }
            catch
            {

                ModelState.AddModelError("", "something went wrong from tryCatch");
                return StatusCode(500, ModelState);
            }
        }
    }
}
