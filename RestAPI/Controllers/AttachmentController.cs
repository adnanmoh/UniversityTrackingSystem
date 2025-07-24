using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AttachmentController : BaseController
    {

        public AttachmentController(IRepositoryManager repositoryManager, IMapper mapper) : base(repositoryManager, mapper)
        {
        }

        [HttpGet("[action]/{groupID}+{subjectID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Attachment>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAttachmentsInCurrentYear(int groupID, int subjectID)
        {
            var obj = await repositoryManager.AttachmentRepository.GetAttachments(groupID, subjectID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mapper.Map<List<AttachmentVM>>(obj));
        }

        [HttpGet("[action]/{id}")]
        [ProducesResponseType(200, Type = typeof(Attachment))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAttachmentById(int id)
        {

            if (!await repositoryManager.AttachmentRepository.ObjExists(id))
            {
                return NotFound();
            }

            var obj = await repositoryManager.AttachmentRepository.GetObjById(id);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mapper.Map<AttachmentVM>(obj));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<string> AddAttachmentByTeacher([FromBody] AttachmentVM objVM)
        {
            try
            {
                var obj = mapper.Map<Attachment>(objVM);

                var res = await repositoryManager.AttachmentRepository.Add(obj);

                return res != null ? "success" : "error";

            }
            catch
            {

                return "error";
            }
        }

        [HttpPut("[action]/{AttachmentID}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> EditeAttachment(int AttachmentID, [FromBody] AttachmentVM objVM)
        {
            try
            {
                var obj = mapper.Map<Attachment>(objVM);
                if (obj == null)
                {
                    return BadRequest(ModelState);
                }
                if (AttachmentID != obj.AttachmentId)
                {
                    return BadRequest(ModelState);
                }
                var existingObj = await repositoryManager.AttachmentRepository.GetObjById(AttachmentID);
                if (existingObj == null)
                {
                    return NotFound();
                }
                mapper.Map(objVM, existingObj);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var res = repositoryManager.AttachmentRepository.Edit(existingObj);

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
