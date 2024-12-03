using System.Data;
using EX2.Models;
using EX2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EX2.services
{
    public class AttachmentService: IAttachmentSerivce
    {
        public readonly IAttachmentRepository _attachmentRepository;
        public AttachmentService(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }
        public DataTable addAttachment(string AttachName, string AttachPath, string UploadDate)
        {
            return _attachmentRepository.addAttachment(AttachName, AttachPath, UploadDate);
        }
        public IEnumerable<Attachment> getByProject(int id)
        {
            return _attachmentRepository.getByProject(id);
        }
    }
}
