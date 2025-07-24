using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TeacherController : BaseController
    {
        public TeacherController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Teacher>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeachers()
        {
            var obj = await repositoryManager.TeacherRepository.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<TeacherVM>>(obj));
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            if (!await repositoryManager.TeacherRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.TeacherRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<TeacherVM>(obj));
        }


        [HttpGet("[action]/{name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Teacher>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeachersByName(string name)
        {
            var obj = await repositoryManager.TeacherRepository.GetTeachersByName(name);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<TeacherVM>>(obj));
        }

        [HttpGet("[action]/{groupID}+{subjectID}+{yearID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Teacher>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeacherHowTeachingSubjectIngroubInYear(int groupID, int subjectID, int yearID)
        {
            var obj = await repositoryManager.TeacherRepository.GetTeacherHowTeachingSubjectIngroubInYear( groupID,  subjectID,  yearID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<TeacherVM>>(obj));
        }

        [HttpGet("[action]/{id}+{password}")]
        [ProducesResponseType(200, Type = typeof(String))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SignIn(int id, string password)
        {
            if (!await repositoryManager.TeacherRepository.ObjExists(id))
            {
                return Ok("id is incorrect");
            }

            bool status = await repositoryManager.TeacherRepository.SignIn(id, password);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (status)
            {
                return Ok("success");
            }
            else
            {
                return Ok("password is incorrect");
            }
        }

        [HttpPut("[action]/{teacherID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditeTeacher(int teacherID, [FromBody] TeacherVM objVM)
        {
            try
            {
                var obj = mapper.Map<Teacher>(objVM);
                if (obj == null)
                {
                    return BadRequest(ModelState);
                }
                if (teacherID != obj.TeacherId)
                {
                    return BadRequest(ModelState);
                }
                var existingObj = await repositoryManager.TeacherRepository.GetObjById(teacherID);
                if (existingObj == null)
                {
                    return NotFound();
                }
                mapper.Map(objVM, existingObj);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var res = repositoryManager.TeacherRepository.EditTeacher(existingObj);

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
