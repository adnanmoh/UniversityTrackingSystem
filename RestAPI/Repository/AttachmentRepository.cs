using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class AttachmentRepository : GenericRepository<Attachment> , IAttachmentRepository
    {
        private readonly UAppContext context;

        public AttachmentRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ICollection<Attachment>> GetAttachments(int groupID, int subjectID)
        {
            Year year = await context.Years.FirstOrDefaultAsync(x => x.Status);
            if (year == null)
            {
                return null;
            }
            else
            {
                return await context.Attachments.Where(x => x.YearId == year.YearId && x.GroupId == groupID ).ToListAsync();
            }
        }
    }
}
