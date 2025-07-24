
using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.Repository
{
    public class StudentRepository: GenericRepository<Student>, IStudentRepository
    {
        private readonly UAppContext context;

        public StudentRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

        

        public async Task<ICollection<Student>> GetStudentsByGroup(int groupID)
        {
            return await context.Students.Where(x => x.GroupId == groupID).ToListAsync();
        }

        public async Task<ICollection<Student>> GetStudentsByName(string name)
        {
            return await context.Students.Where(x => x.Name.StartsWith(name)).ToListAsync();
        }
        public async Task<ICollection<Student>> GetStudentsByPhone(string phone)
        {
            return await context.Students.Where(x => x.Phone.StartsWith(phone)).ToListAsync();
        }

        public async Task<bool> SignIn(int id, string password)
        {
            var student =await context.Students.FindAsync(id);

            if (student == null)
            {
                return false;
            }

            return VerifyPasswordHash(student.PasswordHash, password);
        }

        private bool VerifyPasswordHash(string passwordHash, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }


        

        public async Task<Major> GetStudentMajor(int studentID)
        {
            var stu = await context.Students.FindAsync(studentID);
            if (stu == null)
            {
                return null;
            }

            var group =await context.Groups.FindAsync(stu.GroupId);
            var maj =await context.Majors.FindAsync(group.MajorId);
            return maj;
        }

        public async Task<Level> GetStudentLevel(int studentID)
        {
            var stu =await context.Students.FindAsync(studentID);
            if (stu == null)
            {
                return null;
            }

            var group =await context.Groups.FindAsync(stu.GroupId);
            var level =await context.Levels.FindAsync(group.LevelId);
            return level;
        }

        public async Task<Student> CreateStudent(Student student)
        {
            try
            {
                var obj = new Student
                {
                    Name = student.Name,
                    Phone = student.Phone,
                    IdNumber = student.IdNumber,
                    Password = student.Password,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(student.Password),
                    GroupId = student.GroupId

                };
                var res = await context.Students.AddAsync(obj);
                await context.SaveChangesAsync();
                return res.Entity;
            }
            catch
            {

                return default;
            }
        }
        public async Task<Student> EditStudent(Student student)
        {
            try
            {
                var obj = new Student
                {
                    StudentId = student.StudentId,
                    Name = student.Name,
                    Phone = student.Phone,
                    IdNumber = student.IdNumber,
                    Password = student.Password,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(student.Password),
                    GroupId = student.GroupId

                };
                var res = context.Students.Update(obj);
                await context.SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return default;
            }
        }


    }
}
