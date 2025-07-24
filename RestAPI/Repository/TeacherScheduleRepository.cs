using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class TeacherScheduleRepository : GenericRepository<TeacherSchedule>, ITeacherScheduleRepository
    {
        private readonly UAppContext context;

        public TeacherScheduleRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ICollection<TeacherSchedule>> GetStudentSchedulesByTeacherIDInCurrentYear(int teacherID)
        {
            Year year = await context.Years.FirstOrDefaultAsync(x => x.Status);
            if (year == null)
            {
                return null;
            }
            else
            {
                return await context.TeacherSchedules.Where(x => x.YearId == year.YearId && x.TeacherId == teacherID).ToListAsync();
            }
        }
    }
}
