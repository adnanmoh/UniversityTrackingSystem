using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class YearRepository : GenericRepository<Year> , IYearRepository
    {
        private readonly UAppContext context;

        public YearRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Year>> GetActiveYear()
        {
            var res = await context.Years.Where(x => x.Status).ToListAsync();
            return res  ;
        }
    }
}
