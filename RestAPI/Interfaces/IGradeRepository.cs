using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Interfaces
{
    public interface IGradeRepository : IGenericRepository<Grade>
    {
        Task<ICollection<Grade>> GetPostedGradesForStudentInSubject(int studentID, int subjectID);
        Task<ICollection<Grade>> GetGradesForTeacherInOneSubjectInCurrentYear(int teacherID, int subjectID);
        Task<ICollection<Grade>> GetGradesForOneStudentInCurrentYear(int studentID);

    }
}
