using System.Data;
using EX2.Models;
using Microsoft.AspNetCore.Mvc;

namespace EX2.Repositories
{
    public interface IAttachmentRepository
    {
        public DataTable addAttachment(string AttachName, string AttachPath, string UploadDate);
        public IEnumerable<Attachment> getByProject(int id);
    }
}
