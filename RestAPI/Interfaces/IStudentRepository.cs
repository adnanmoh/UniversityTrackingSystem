using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        
        
        Task<ICollection<Student>> GetStudentsByGroup(int groupID);
        Task<ICollection<Student>> GetStudentsByName(String name);
        Task<ICollection<Student>> GetStudentsByPhone(String Phone);
        Task<bool> SignIn(int id, String password);
        Task<Major> GetStudentMajor(int studentID);
        Task<Level> GetStudentLevel(int studentID);
        Task<Student> CreateStudent(Student student);
        Task<Student> EditStudent(Student student);
    }
}
