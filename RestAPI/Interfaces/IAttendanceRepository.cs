using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Interfaces
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        Task<ICollection<Attendance>> GetAllAttendancesForStudentInSubject(int studentID, int SubjectID);

    }
}
