using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Repository
{
    public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
    {
        private readonly UAppContext context;

        public AttendanceRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

       /* public int Add(AttendanceVM obj)
        {
            
            try
            {
                var attendance = new Attendance
                {
                    State = obj.State,
                    DateTime = obj.DateTime,
                    Reason = obj.Reason,
                    StudentId = obj.StudentId,
                    SubjectId = obj.SubjectId,
                    LectureId = obj.LectureId,
                    

                };
                context.Attendances.Add(attendance);
                var save = context.SaveChanges();
                return save;
            }
            catch
            {

                return 0;
            }
            
        }*/

       

        public async Task<ICollection<Attendance>> GetAllAttendancesForStudentInSubject(int studentID, int SubjectID)
        {
            return await context.Attendances.Where(x => x.SubjectId == SubjectID && x.StudentId == studentID).ToListAsync();
        }
    }
}
