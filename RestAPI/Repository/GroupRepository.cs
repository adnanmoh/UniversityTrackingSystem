using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        private readonly UAppContext context;

        public GroupRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ICollection<Group>> GetGroupsThatTheTeacherTeachInCurrentYear(int teacherID)
        {
            Year currentYear =await context.Years.FirstOrDefaultAsync(x => x.Status);

            var groups = await context.Groups
                .Where(g => g.Teachings.Any(t => t.TeacherId == teacherID && t.YearId == currentYear.YearId))
                .Select(g => new Group
                {
                    GroupId = g.GroupId,
                    YearId = g.Teachings.FirstOrDefault().YearId,
                    Name = g.Name,
                    LevelId = g.LevelId,
                    MajorId = g.MajorId,
                    ParentGroupId = g.ParentGroupId
                })
                .ToListAsync();

            

            return groups;
        }
        public async Task<ICollection<Group>> GetAllGroupsInCurrentYear()
        {
            Year currentYear = await context.Years.FirstOrDefaultAsync(x => x.Status);

            var groups = await context.Groups.Where(x => x.YearId == currentYear.YearId).ToListAsync();

            return groups;
        }

        public async Task<ICollection<Group>> GetAllGroupsInCurrentYearAndItsParent()
        {
            Year currentYear = await context.Years.FirstOrDefaultAsync(x => x.Status);

            var groups = await context.Groups.Where(x => x.YearId == currentYear.YearId && x.ParentGroupId == null).ToListAsync();

            return groups;
        }


    }
}
