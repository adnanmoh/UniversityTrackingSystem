using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentController : BaseController
    {
        public StudentController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStudents()
        {
            var obj = await repositoryManager.StudentRepository.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<StudentVM>>(obj));
        }
       
        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(Student))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStudentById(int id)
        {
            if (!await repositoryManager.StudentRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.StudentRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<StudentVM>(obj));
        }

        [HttpGet("[action]/{groupID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStudentsByGroup(int groupID)
        {
            var obj =await repositoryManager.StudentRepository.GetStudentsByGroup(groupID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<StudentVM>>(obj));
        }

        [HttpGet("[action]/{name}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetStudentsByName(string name)
        {
            var obj =await repositoryManager.StudentRepository.GetStudentsByName(name);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<StudentVM>>(obj));
        }

        [HttpGet("[action]/{id}+{password}")]
        [ProducesResponseType(200, Type = typeof(String))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SignIn(int id ,string password)
        {
            if (!await repositoryManager.StudentRepository.ObjExists(id))
            {
                return Ok("id is incorrect");
            }

            bool status = await repositoryManager.StudentRepository.SignIn(id, password);
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

        [HttpGet("[action]/{studentID}")]
        [ProducesResponseType(200, Type = typeof(String))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetStudentMajor(int studentID)
        {
            if (!await repositoryManager.StudentRepository.ObjExists(studentID))
            {
                return NotFound();
            }

            var obj =await repositoryManager.StudentRepository.GetStudentMajor(studentID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<MajorVM>(obj));
        }

        [HttpGet("[action]/{studentID}")]
        [ProducesResponseType(200, Type = typeof(String))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> GetStudentLevel(int studentID)
        {
            if (!await repositoryManager.StudentRepository.ObjExists(studentID))
            {
                return NotFound();
            }

            var obj = await repositoryManager.StudentRepository.GetStudentLevel(studentID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<LevelVM>(obj));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<string> CreateStudent([FromBody] StudentVM objVM)
        {
            try
            {
                var obj = mapper.Map<Student>(objVM);
                

                var res = await repositoryManager.StudentRepository.CreateStudent(obj);

                return res != null ? "success" : "error";

            }
            catch
            {

                return "error";
            }
        }

        [HttpPut("[action]/{studentID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditeStudent(int studentID , [FromBody] StudentVM objVM)
        {
            try
            {
                var obj = mapper.Map<Student>(objVM);
                if (obj == null)
                {
                    return BadRequest(ModelState);
                }
                if (studentID != obj.StudentId)
                {
                    return BadRequest(ModelState);
                }
                var existingObj = await repositoryManager.StudentRepository.GetObjById(studentID);
                if (existingObj == null)
                {
                    return NotFound();
                }
                mapper.Map(objVM, existingObj);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                var res = repositoryManager.StudentRepository.EditStudent(existingObj);

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
