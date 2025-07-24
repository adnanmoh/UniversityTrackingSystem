using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class LectureForSubjectRepository : GenericRepository<LectureForSubject>, ILectureForSubjectRepository
    {
        private readonly UAppContext context;

        public LectureForSubjectRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<ICollection<LectureForSubject>> GetAllLectureForOneSubject(int subjectID)
        {
            try
            {
                
                List<LectureForSubject> res =await context.LecturesForSubjects.Where(x=>x.SubjectId == subjectID).ToListAsync();
                return  res;
            }
            catch
            {

                return default;
            }
        }

        public async Task<int> GetNumberOfLectureForOneSubject(int subjectID)
        {
            try
            {

                List<LectureForSubject> res = await context.LecturesForSubjects.Where(x => x.SubjectId == subjectID).ToListAsync();
                return res.Count;
            }
            catch
            {

                return 0;
            }
        }

        public async Task<int> RemoveRange(List<LectureForSubject> subjects)
        {
            try
            {
                context.LecturesForSubjects.RemoveRange(subjects);
                var res = await context.SaveChangesAsync();
                return res;


            }
            catch (Exception)
            {

                return 0; 
            }
        }

        
    }
}
