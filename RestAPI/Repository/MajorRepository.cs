using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class MajorRepository : GenericRepository<Major>, IMajorRepository
    {
        private readonly UAppContext context;

        public MajorRepository(UAppContext context ) : base(context)
        {
            this.context = context;
        }
        
        


    }
}
