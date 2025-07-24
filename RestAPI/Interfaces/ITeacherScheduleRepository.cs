using RestAPI.Models;

namespace RestAPI.Interfaces
{
    public interface ITeacherScheduleRepository : IGenericRepository<TeacherSchedule>
    {
        Task<ICollection<TeacherSchedule>> GetStudentSchedulesByTeacherIDInCurrentYear(int teacherID);
    }
}
