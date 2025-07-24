using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class CollegeRepository : GenericRepository<College>, ICollegeRepository
    {
        private readonly UAppContext context;

        public CollegeRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }
    }
}
