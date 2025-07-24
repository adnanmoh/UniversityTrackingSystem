using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class LevelRepository : GenericRepository<Level>  , ILevelRepository
    {
        private readonly UAppContext context;

        public LevelRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }
    }
}
