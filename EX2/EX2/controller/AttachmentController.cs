using EX2.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using EX2.Models;

namespace EX2.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentSerivce _attachmentSerivce;
        public AttachmentController(IAttachmentSerivce attachmentSerivce)
        {
            _attachmentSerivce = attachmentSerivce;
        }
        [HttpPost]
        public IActionResult addAttachment([FromQuery] string AttachName, string AttachPath,string UploadDate)
        {
            DataTable dt= _attachmentSerivce.addAttachment(AttachName, AttachPath, UploadDate);
            return Ok("Attachment was created successfully!!!!");
        }
        
        [HttpGet]
        public IEnumerable<Attachment> getByProject(int id)
        {
            return _attachmentSerivce.getByProject(id);
        }
    }
}
