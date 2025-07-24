using RestAPI.Models;

namespace RestAPI.Interfaces
{
    public interface IStudentScheduleRepository : IGenericRepository<StudentSchedule>
    {

        Task<ICollection<StudentSchedule>> GetStudentSchedulesByGroupIDInCurrentYear(int groupID);


    }
}
