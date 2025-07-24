using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Repository
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        private readonly UAppContext context;

        public GradeRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

        

       

        public async Task<ICollection<Grade>> GetGradesForTeacherInOneSubjectInCurrentYear(int teacherID, int subjectID)
        {
            Year year = await context.Years.FirstOrDefaultAsync(x => x.Status == true);
            if (year == null)
            {
                return null;
            }
            else
            {
                return await context.Grades.Where(x => x.YearId == year.YearId && x.SubjectId == subjectID && x.TeacherId == teacherID).ToListAsync();
            }
        }

        public async Task<ICollection<Grade>> GetPostedGradesForStudentInSubject(int studentID, int subjectID)
        {
            
                return await context.Grades.Where(x => x.StudentId == studentID && x.SubjectId == subjectID && x.IsPosted == true).ToListAsync();
            
        }

        public async Task<ICollection<Grade>> GetGradesForOneStudentInCurrentYear(int studentID)
        {
            Year year = await context.Years.FirstOrDefaultAsync(x => x.Status == true);
            if (year == null)
            {
                return null;
            }
            else
            {
                return await context.Grades.Where(x => x.StudentId == studentID && x.YearId == year.YearId ).ToListAsync();
            }
        }
    }
}
