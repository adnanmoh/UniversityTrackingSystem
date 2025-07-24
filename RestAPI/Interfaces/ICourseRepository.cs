using RestAPI.Models;

namespace RestAPI.Interfaces
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<ICollection<Course>> GetCourses(int groupID, int subjectID);
    }
}
