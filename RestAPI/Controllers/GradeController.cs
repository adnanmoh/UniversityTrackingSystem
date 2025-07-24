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
    public class GradeController : BaseController
    {
        public GradeController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]/{studentID}+{subjectID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Grade>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPostedGradesForStudentInSubject(int studentID, int subjectID)
        {
            var obj = await repositoryManager.GradeRepository.GetPostedGradesForStudentInSubject(studentID, subjectID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<GradeVM>>(obj));
        }

        [HttpGet("[action]/{teacherID}+{subjectID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Grade>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGradesForTeacherInOneSubjectInCurenntYear(int teacherID, int subjectID)
        {
            var obj =await repositoryManager.GradeRepository.GetGradesForTeacherInOneSubjectInCurrentYear(teacherID, subjectID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<GradeVM>>(obj));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<string> AddGradeByTeacher([FromBody] GradeVM objVM)
        {
            try
            {
                var obj = mapper.Map<Grade>(objVM);

                var res = await repositoryManager.GradeRepository.Add(obj);

                return res != null ? "success" : "error";

            }
            catch
            {

                return "error";
            }
        }

        [HttpPut("[action]/{GradeID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditeGrade(int GradeID, [FromBody] GradeVM objVM)
        {
            try
            {
                var obj = mapper.Map<Grade>(objVM);
                if (obj == null)
                {
                    return BadRequest(ModelState);
                }
                if (GradeID != obj.GradeId)
                {
                    return BadRequest(ModelState);
                }
                var existingObj = await repositoryManager.GradeRepository.GetObjById(GradeID);
                if (existingObj == null)
                {
                    return NotFound();
                }
                mapper.Map(objVM, existingObj);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var res = repositoryManager.GradeRepository.Edit(existingObj);

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
