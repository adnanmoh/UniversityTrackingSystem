using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class SubjectsInMajorsLevelRepository : GenericRepository<SubjectsInMajorsLevel> , ISubjectsInMajorsLevelRepository
    {
        private readonly UAppContext context;

        public SubjectsInMajorsLevelRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ICollection<SubjectsInMajorsLevel>> GetSubjectsInMajorsLevelByMajorID(int majorID)
        {
            return await context.SubjectsInMajorsLevel.Where(x => x.MajorId == majorID).ToListAsync();
        }
    }
}
