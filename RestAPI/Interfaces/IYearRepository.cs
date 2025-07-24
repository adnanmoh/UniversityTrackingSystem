using RestAPI.Models;

namespace RestAPI.Interfaces
{
    public interface IYearRepository : IGenericRepository<Year>
    {
        Task<List<Year>> GetActiveYear();
    }
}
