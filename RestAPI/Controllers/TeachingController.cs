using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TeachingController : BaseController
    {
        public TeachingController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]/{teacherID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Group>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGroupsThatTheTeacherTeachThemByTeacherID(int teacherID)
        {
            var obj =await repositoryManager.TeachingRepository.GetGroupsThatTheTeacherTeachThemByTeacherID(teacherID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<GroupVM>>(obj));
        }

        [HttpGet("[action]/{teacherID}+{SubjectID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Group>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGroupsThatTheTeacherTeachThemByTeacherIDAndSubjectID(int teacherID , int SubjectID)
        {
            var obj = await repositoryManager.TeachingRepository.GetGroupsThatTheTeacherTeachThemByTeacherIDAndSubjectID(teacherID , SubjectID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<GroupVM>>(obj));
        }


        [HttpGet("[action]/{teacherID}+{groupID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Group>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSubjectThatTheTeacherTeachThemByTeacherIDAndGroupID(int teacherID, int groupID)
        {
            var obj = await repositoryManager.TeachingRepository.GetSubjectThatTheTeacherTeachThemByTeacherIDAndGroupID(teacherID, groupID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<SubjectVM>>(obj));
        }

        [HttpGet("[action]/{teacherID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Group>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSubjectThatTheTeachereachThemByTeacherID(int teacherID)
        {
            var obj =await repositoryManager.TeachingRepository.GetSubjectThatTheTeacherTeachThemByTeacherID(teacherID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok( mapper.Map<List<SubjectVM>>(obj));
        }

        [HttpGet("[action]/{studentID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Group>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetSubjectThatTheStudentStudyThemByStudentID(int studentID)
        {
            var obj = await repositoryManager.TeachingRepository.GetSubjectThatTheStudentStudyThemByStudentID(studentID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<SubjectVM>>(obj));
        }


    }
}
