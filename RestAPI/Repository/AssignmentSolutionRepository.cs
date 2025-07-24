using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Repository
{
    public class AssignmentSolutionRepository : GenericRepository<AssignmentSolution>, IAssignmentSolutionRepository
    {
        private readonly UAppContext context;

        public AssignmentSolutionRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

       /* public int Add(AssignmentSolutionVM obj)
        {
            try
            {
                var AssignmentSolution = new AssignmentSolution
                {
                    StudentId = obj.StudentId,
                    AssignmentId = obj.AssignmentId,
                    Anote = obj.Anote,
                    Afile = obj.Afile,
                    DateTime = obj.DateTime
                };
                context.AssignmentSolutions.Add(AssignmentSolution);
                var save = context.SaveChanges();
                return save;
            }
            catch
            {
                
                return 0;
            }
        }*/

       

        /*public async Task<ICollection<AssignmentSolution>> GetAssignmentSolutionByStudentIDAndAssignmentSolutionID(int assignmentSolutionID, int studentID)
        {
            try
            {
                return await context.AssignmentSolutions.Where(x => x.AssignmentId == assignmentSolutionID && x.StudentId == studentID).ToListAsync();
            }
            catch 
            {

                return default;
            }
        }*/
    }
}
