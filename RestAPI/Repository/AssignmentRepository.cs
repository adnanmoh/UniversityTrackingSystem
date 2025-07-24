using AutoMapper;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;
using Microsoft.EntityFrameworkCore;

namespace RestAPI.Repository
{
    public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentRepository
    {
        private readonly UAppContext context;

        public AssignmentRepository(UAppContext context ):base (context)
        {
            this.context = context;
        }



        public async Task<ICollection<Assignment>> GetAssignments(int groupID, int subjectID, int teacherID)
        {
            Year year = await context.Years.FirstOrDefaultAsync(x => x.Status);
            if(year == null)
            {
                return null;
            }
            else
            {
                return await context.Assignments.Where(x => x.YearId == year.YearId && x.GroupId == groupID && x.TeacherId == teacherID).ToListAsync();
            }
            
        }

        
       
    }
}
