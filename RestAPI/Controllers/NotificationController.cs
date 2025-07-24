using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class NotificationController : BaseController
    {
        public NotificationController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]/{receiverID}")]
        [ProducesResponseType(200, Type = typeof(Notification))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetNotificationsByReceiverIDAndIsReadFalse(int receiverID)
        {

            var obj =await repositoryManager.NotificationRepository.GetNotificationsByReceiverIDAndIsReadFalse(receiverID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<List<NotificationVM>>(obj));
        }


        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<string> AddNotification([FromBody] NotificationVM objVM)
        {
            try
            {
                var obj = mapper.Map<Notification>(objVM);

                var res = await repositoryManager.NotificationRepository.Add(obj);

                return res != null ? "success" : "error";

            }
            catch
            {

                return "error";
            }
        }

        [HttpPut("[action]/{NotificationID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditeNotification(int NotificationID, [FromBody] NotificationVM objVM)
        {
            try
            {
                var obj = mapper.Map<Notification>(objVM);
                if (obj == null)
                {
                    return BadRequest(ModelState);
                }
                if (NotificationID != obj.NotificationId)
                {
                    return BadRequest(ModelState);
                }
                var existingObj = await repositoryManager.NotificationRepository.GetObjById(NotificationID);
                if (existingObj == null)
                {
                    return NotFound();
                }
                mapper.Map(objVM, existingObj);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var res = repositoryManager.NotificationRepository.Edit(existingObj);

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
