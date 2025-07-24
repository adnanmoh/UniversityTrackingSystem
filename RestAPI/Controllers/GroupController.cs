using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class GroupController : BaseController
    {
        public GroupController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(Group))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGroupById(int id)
        {
            if (!await repositoryManager.GroupRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.GroupRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<GroupVM>(obj));
        }

        [HttpGet("[action]/{teacherID}")]
        [ProducesResponseType(200, Type = typeof(Group))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGroupsThatTheTeacherTeachInCurrentYear(int teacherID)
        {
           

            var Group = await repositoryManager.GroupRepository.GetGroupsThatTheTeacherTeachInCurrentYear(teacherID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Group == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(mapper.Map<List<GroupVM>>(Group));
        }
    }
}
