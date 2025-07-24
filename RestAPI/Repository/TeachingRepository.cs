using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class TeachingRepository : GenericRepository<Teaching>, ITeachingRepository
    {
        private readonly UAppContext context;

        public TeachingRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<ICollection<Teaching>> GetAllInCurrentYear()
        {
            Year year = await context.Years.FirstOrDefaultAsync(x => x.Status == true);
            if (year == null)
            {
                return null;
            }
            else
            {
                var Teachings = await context.Teachings.Where(x => x.YearId == year.YearId).ToListAsync();
                return Teachings;
            }
        }

        public async Task<ICollection<Group>> GetGroupsThatTheTeacherTeachThemByTeacherID(int TeacherID)
        {
            Year year = await context.Years.FirstOrDefaultAsync(x => x.Status == true);
            if (year == null)
            {
                return null;
            }
            else
            {
                var groups =await context.Groups.Where(group => context.Teachings
           .Where(teaching => teaching.TeacherId == TeacherID && teaching.YearId == year.YearId)
           .Select(teaching => teaching.GroupId)
           .Contains(group.GroupId)).ToListAsync();
                return groups;
            }
        }

        public async Task<ICollection<Group>> GetGroupsThatTheTeacherTeachThemByTeacherIDAndSubjectID(int TeacherID, int SubjectID)
        {
            Year year =await context.Years.FirstOrDefaultAsync(x => x.Status == true);
            if (year == null)
            {
                return null;
            }
            else
            {
                var groups =await context.Groups.Where(group => context.Teachings
           .Where(teaching => teaching.TeacherId == TeacherID && teaching.SubjectId == SubjectID && teaching.YearId == year.YearId)
           .Select(teaching => teaching.GroupId)
           .Contains(group.GroupId)).ToListAsync();
                return groups;
            }
        }

        public async Task<ICollection<Subject>> GetSubjectThatTheStudentStudyThemByStudentID(int StudentID)
        {
            Year year =await context.Years.FirstOrDefaultAsync(x => x.Status);
            Student student =await context.Students.FirstOrDefaultAsync(x => x.StudentId == StudentID);
            if (year == null || student == null)
            {
                return null;
            }
            else
            {
                var subjects =await context.Subjects
               .Where(subject => context.Teachings
                   .Where(teaching =>  teaching.GroupId == student.GroupId && teaching.YearId == year.YearId)
                   .Select(teaching => teaching.SubjectId)
                   .Contains(subject.SubjectId)).ToListAsync();
                return subjects;
            }
        }

        public async Task<ICollection<Subject>> GetSubjectThatTheTeacherTeachThemByTeacherID(int TeacherID)
        {
            Year year =await context.Years.FirstOrDefaultAsync(x => x.Status);
            if (year == null)
            {
                return null;
            }
            else
            {
                var subjects =await context.Subjects
               .Where(subject => context.Teachings
                   .Where(teaching => teaching.TeacherId == TeacherID  && teaching.YearId == year.YearId)
                   .Select(teaching => teaching.SubjectId)
                   .Contains(subject.SubjectId)).ToListAsync();
                return subjects;
            }
        }

        public async Task<ICollection<Subject>> GetSubjectThatTheTeacherTeachThemByTeacherIDAndGroupID(int TeacherID, int GroupID)
        {
            Year year =await context.Years.FirstOrDefaultAsync(x => x.Status == true);
            if (year == null)
            {
                return null;
            }
            else
            {
                 var subjects =await context.Subjects
                .Where(subject => context.Teachings
                    .Where(teaching => teaching.TeacherId == TeacherID && teaching.GroupId == GroupID && teaching.YearId == year.YearId)
                    .Select(teaching => teaching.SubjectId)
                    .Contains(subject.SubjectId)).ToListAsync();
                return subjects;
            }
        }
    }
}
