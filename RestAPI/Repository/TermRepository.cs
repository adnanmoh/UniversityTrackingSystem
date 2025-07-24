using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class TermRepository : GenericRepository<Term>, ITermRepository
    {
        private readonly UAppContext context;

        public TermRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }
    }
}
