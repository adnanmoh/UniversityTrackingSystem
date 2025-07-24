using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AssignmentController : BaseController
    {
        public AssignmentController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]/{groupID}+{subjectID}+{teacherID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Assignment>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAssignments(int groupID, int subjectID, int teacherID)
        {
            var obj = await repositoryManager.AssignmentRepository.GetAssignments(groupID, subjectID, teacherID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<AssignmentVM>>(obj));
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(Assignment))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAssignmentById(int id)
        {

            if (!await repositoryManager.AssignmentRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.AssignmentRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<AssignmentVM>(obj));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<string> AddAssignmentByTeacher([FromBody] AssignmentVM objVM)
        {
            try
            {
                var obj = mapper.Map<Assignment>(objVM);

                var res = await repositoryManager.AssignmentRepository.Add(obj);

                return res != null ? "success" : "error";

            }
            catch
            {

                return "error";
            }
        }

        [HttpPut("[action]/{AssignmentID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditeAssignment(int AssignmentID, [FromBody] AssignmentVM objVM)
        {
            try
            {
                var obj = mapper.Map<Assignment>(objVM);
                if (obj == null)
                {
                    return BadRequest(ModelState);
                }
                if (AssignmentID != obj.AssignmentId)
                {
                    return BadRequest(ModelState);
                }
                var existingObj = await repositoryManager.AssignmentRepository.GetObjById(AssignmentID);
                if (existingObj == null)
                {
                    return NotFound();
                }
                mapper.Map(objVM, existingObj);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var res = repositoryManager.AssignmentRepository.Edit(existingObj);

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
