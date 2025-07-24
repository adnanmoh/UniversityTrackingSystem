using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly UAppContext context;

        public SubjectRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }
        
    }
}
