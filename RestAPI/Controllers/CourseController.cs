using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CourseController : BaseController
    {
        public CourseController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]/{groupID}+{subjectID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCoursesInCurrentYear(int groupID, int subjectID)
        {
            var obj = await repositoryManager.CourseRepository.GetCourses(groupID, subjectID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<CourseVM>>(obj));
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(Course))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCourseById(int id)
        {

            if (!await repositoryManager.CourseRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.CourseRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<CourseVM>(obj));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<string> AddCourseByTeacher([FromBody] CourseVM objVM)
        {
            try
            {
                var obj = mapper.Map<Course>(objVM);

                var res = await repositoryManager.CourseRepository.Add(obj);

                return res != null ? "success" : "error";

            }
            catch
            {

                return "error";
            }
        }

        [HttpPut("[action]/{CourseID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditeCourse(int CourseID, [FromBody] CourseVM objVM)
        {
            try
            {
                var obj = mapper.Map<Course>(objVM);
                if (obj == null)
                {
                    return BadRequest(ModelState);
                }
                if (CourseID != obj.CourseId)
                {
                    return BadRequest(ModelState);
                }
                var existingObj = await repositoryManager.CourseRepository.GetObjById(CourseID);
                if (existingObj == null)
                {
                    return NotFound();
                }
                mapper.Map(objVM, existingObj);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var res = repositoryManager.CourseRepository.Edit(existingObj);

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
