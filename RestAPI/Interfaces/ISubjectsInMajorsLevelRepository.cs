using RestAPI.Models;

namespace RestAPI.Interfaces
{
    public interface ISubjectsInMajorsLevelRepository : IGenericRepository<SubjectsInMajorsLevel>
    {
        Task<ICollection<SubjectsInMajorsLevel>> GetSubjectsInMajorsLevelByMajorID(int majorID);
    }
}
