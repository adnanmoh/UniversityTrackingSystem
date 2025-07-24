using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AssignmentSolutionController : BaseController
    {
        public AssignmentSolutionController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]/{assignmentID}+{studentID}")]
        [ProducesResponseType(200, Type = typeof(AssignmentSolution))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAssignmentSolutionsById(int studentID ,int assignmentID)
        {
            if (!await repositoryManager.AssignmentSolutionRepository.ObjExists(new object[] { studentID, assignmentID }))
            {
                return NotFound();
            }

            var obj = await repositoryManager.AssignmentSolutionRepository.GetObjById(new object[] { studentID, assignmentID });
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<AssignmentSolutionVM>(obj));
        }

        /*[HttpGet("[action]/{assignmentSolutionID}+{studentID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AssignmentSolution>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAssignmentSolutionByStudentIDAndAssignmentSolutionID(int assignmentSolutionID, int studentID)
        {
            var obj = await repositoryManager.AssignmentSolutionRepository.GetAssignmentSolutionByStudentIDAndAssignmentSolutionID(assignmentSolutionID,  studentID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<AssignmentSolutionVM>>(obj));
        }*/

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<string> AddAssignmentSolutionByStudent([FromBody] AssignmentSolutionVM objVM)
        {
            try
            {
                var obj = mapper.Map<AssignmentSolution>(objVM);

                var res = await repositoryManager.AssignmentSolutionRepository.Add(obj);

                return res != null ? "success" : "error";

            }
            catch
            {

                return "error";
            }
        }

        [HttpPut("[action]/{assignmentID}+{studentID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditeAssignmentSolution(int studentID, int  assignmentID ,  [FromBody] AssignmentSolutionVM objVM)
        {
            try
            {
                var obj = mapper.Map<AssignmentSolution>(objVM);
                if (obj == null)
                {
                    return BadRequest(ModelState);
                }
                if (studentID+assignmentID !=obj.StudentId+obj.AssignmentId)
                {
                    return BadRequest(ModelState);
                }
                var existingObj = await repositoryManager.AssignmentSolutionRepository.GetObjById(new object[] { studentID, assignmentID });
                if (existingObj == null)
                {
                    return NotFound();
                }
                mapper.Map(objVM, existingObj);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var res = repositoryManager.AssignmentSolutionRepository.Edit(existingObj);

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
