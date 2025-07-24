using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class CourseRepository : GenericRepository<Course> , ICourseRepository
    {
        private readonly UAppContext context;

        public CourseRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ICollection<Course>> GetCourses(int groupID, int subjectID)
        {
            Year year = await context.Years.FirstOrDefaultAsync(x => x.Status);
            if (year == null)
            {
                return null;
            }
            else
            {
                return await context.Courses.Where(x => x.YearId == year.YearId && x.GroupId == groupID).ToListAsync();
            }
        }
    }
}
