using RestAPI.Models;

namespace RestAPI.Interfaces
{
    public interface IGroupRepository : IGenericRepository<Group>
    {
        Task<ICollection<Group>> GetGroupsThatTheTeacherTeachInCurrentYear(int teacherID);
        Task<ICollection<Group>> GetAllGroupsInCurrentYear();
        Task<ICollection<Group>> GetAllGroupsInCurrentYearAndItsParent();


    }
}
