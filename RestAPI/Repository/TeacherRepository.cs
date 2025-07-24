using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Repository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly UAppContext context;

        public TeacherRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

       

        public async Task<ICollection<Teacher>> GetTeacherHowTeachingSubjectIngroubInYear(int groupID, int subjectID, int yearID)
        {
            
                return await context.Teachings.Where(x => x.YearId == yearID && x.GroupId == groupID && x.SubjectId == subjectID).Select(x => new Teacher
                {
                    TeacherId = x.TeacherId,
                    Name = x.Teacher.Name,
                    Phone = x.Teacher.Phone,
                    Email = x.Teacher.Email,
                    IdNumber = x.Teacher.IdNumber,
                    
                }).ToListAsync();
            
        }

        public async Task<ICollection<Teacher>> GetTeachersByName(string name)
        {
            return await context.Teachers.Where(x => x.Name.StartsWith(name)).ToListAsync();
        }

        public async Task<bool> SignIn(int id, string password)
        {
            var Teacher =await  context.Teachers.FindAsync(id);

            if (Teacher == null)
            {
                return false;
            }

            return VerifyPasswordHash(Teacher.PasswordHash, password);
        }

        private bool VerifyPasswordHash(string passwordHash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }


        public async Task<Teacher> EditTeacher(Teacher Teacher)
        {
            try
            {
                var obj = new Teacher
                {
                    TeacherId = Teacher.TeacherId,
                    Name = Teacher.Name,
                    Phone = Teacher.Phone,
                    Email = Teacher.Email,
                    IdNumber = Teacher.IdNumber,
                    Password = Teacher.Password,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(Teacher.Password),


                };
                var res = context.Teachers.Update(obj);
                var save =await context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default;
            }
        }

        public async Task<Teacher> CreateTeacher(Teacher Teacher)
        {
            try
            {
               
                var obj = new Teacher
                {
                    Name = Teacher.Name,
                    Phone = Teacher.Phone,
                    Email = Teacher.Email,
                    IdNumber = Teacher.IdNumber,
                    Password = Teacher.Password,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(Teacher.Password),


                };

         
                var res = await context.Teachers.AddAsync(obj);
                await context.SaveChangesAsync();
                return res.Entity;
            }
            catch
            {

                return default;
            }
        }


    }
}
