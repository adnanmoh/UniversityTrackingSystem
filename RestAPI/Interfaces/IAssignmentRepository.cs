using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Interfaces
{
    public interface IAssignmentRepository : IGenericRepository<Assignment>
    {

        Task<ICollection<Assignment>> GetAssignments(int groupID , int subjectID ,int teacherID);


    }
}
