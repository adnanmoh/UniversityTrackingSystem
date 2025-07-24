using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class StudentScheduleRepository : GenericRepository<StudentSchedule>, IStudentScheduleRepository
    {
        private readonly UAppContext context;

        public StudentScheduleRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ICollection<StudentSchedule>> GetStudentSchedulesByGroupIDInCurrentYear(int groupID)
        {
            Year year = await context.Years.FirstOrDefaultAsync(x => x.Status);
            if (year == null)
            {
                return null;
            }
            else
            {
                return await context.StudentSchedules.Where(x => x.YearId == year.YearId && x.GroupId == groupID ).ToListAsync();
            }

        }
    }
}
