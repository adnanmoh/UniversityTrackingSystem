using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Interfaces
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
       
        Task<ICollection<Teacher>> GetTeachersByName(String name);
        Task<bool> SignIn(int id, String password);
        Task<ICollection<Teacher>> GetTeacherHowTeachingSubjectIngroubInYear(int groupID, int subjectID, int yearID);
        Task<Teacher> EditTeacher(Teacher Teacher);
        Task<Teacher> CreateTeacher(Teacher Teacher);

    }
}
