using RestAPI.Models;

namespace RestAPI.Interfaces
{
    public interface IAttachmentRepository : IGenericRepository<Attachment>
    {
        Task<ICollection<Attachment>> GetAttachments(int groupID, int subjectID);
    }
}
