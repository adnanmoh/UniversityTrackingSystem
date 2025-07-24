using RestAPI.Models;

namespace RestAPI.Interfaces
{
    public interface ITeachingRepository : IGenericRepository<Teaching>
    {
        Task<ICollection<Teaching>> GetAllInCurrentYear();
        Task<ICollection<Group>> GetGroupsThatTheTeacherTeachThemByTeacherID(int TeacherID);
        Task<ICollection<Group>> GetGroupsThatTheTeacherTeachThemByTeacherIDAndSubjectID(int TeacherID , int SubjectID);
        Task<ICollection<Subject>> GetSubjectThatTheTeacherTeachThemByTeacherIDAndGroupID(int TeacherID , int GroupID);
        Task<ICollection<Subject>> GetSubjectThatTheTeacherTeachThemByTeacherID(int TeacherID );
        Task<ICollection<Subject>> GetSubjectThatTheStudentStudyThemByStudentID(int StudentID);

    }
}
