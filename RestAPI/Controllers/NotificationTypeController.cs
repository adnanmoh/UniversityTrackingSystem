using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class NotificationTypeController : BaseController
    {
        public NotificationTypeController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NotificationType>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetNotificationTypes()
        {
            var obj = await repositoryManager.NotificationTypeRepository.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<NotificationTypeVM>>(obj));
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(NotificationType))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetNotificationTypeById(int id)
        {
            if (!await repositoryManager.NotificationTypeRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.NotificationTypeRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<NotificationTypeVM>(obj));
        }
    }
}
