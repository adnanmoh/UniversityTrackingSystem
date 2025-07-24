using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;
using RestAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UAppContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("local")));

builder.Services.AddIdentity<SysUser, IdentityRole>().AddEntityFrameworkStores<UAppContext>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// ---------    repository     -------- /

// ---------    repository     -------- /

builder.Services.AddScoped<IGenericRepository<Student>, GenericRepository<Student>>();
builder.Services.AddScoped<IGenericRepository<Assignment>, GenericRepository<Assignment>>();
builder.Services.AddScoped<IGenericRepository<AssignmentSolution>, GenericRepository<AssignmentSolution>>();
builder.Services.AddScoped<IGenericRepository<Group>, GenericRepository<Group>>();
builder.Services.AddScoped<IGenericRepository<Lecture>, GenericRepository<Lecture>>();
builder.Services.AddScoped<IGenericRepository<StudentSchedule>, GenericRepository<StudentSchedule>>();
builder.Services.AddScoped<IGenericRepository<Subject>, GenericRepository<Subject>>();
builder.Services.AddScoped<IGenericRepository<Teacher>, GenericRepository<Teacher>>();
builder.Services.AddScoped<IGenericRepository<TeacherSchedule>, GenericRepository<TeacherSchedule>>();
builder.Services.AddScoped<IGenericRepository<Grade>, GenericRepository<Grade>>();
builder.Services.AddScoped<IGenericRepository<LectureForSubject>, GenericRepository<LectureForSubject>>();
builder.Services.AddScoped<IGenericRepository<Year>, GenericRepository<Year>>();
builder.Services.AddScoped<IGenericRepository<NotificationType>, GenericRepository<NotificationType>>();
builder.Services.AddScoped<IGenericRepository<Attendance>, GenericRepository<Attendance>>();
builder.Services.AddScoped<IGenericRepository<Notification>, GenericRepository<Notification>>();
builder.Services.AddScoped<IGenericRepository<Major>, GenericRepository<Major>>();
builder.Services.AddScoped<IGenericRepository<Level>, GenericRepository<Level>>();
builder.Services.AddScoped<IGenericRepository<SubjectsInMajorsLevel>, GenericRepository<SubjectsInMajorsLevel>>();
builder.Services.AddScoped<IGenericRepository<Course>, GenericRepository<Course>>();
builder.Services.AddScoped<IGenericRepository<Attachment>, GenericRepository<Attachment>>();
builder.Services.AddScoped<IGenericRepository<College>, GenericRepository<College>>();
builder.Services.AddScoped<IGenericRepository<Term>, GenericRepository<Term>>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IStudentScheduleRepository, StudentScheduleRepository>();
builder.Services.AddScoped<ITeacherScheduleRepository, TeacherScheduleRepository>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<ILectureRepository, LectureRepository>();
builder.Services.AddScoped<IMajorRepository, MajorRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAssignmentSolutionRepository, AssignmentSolutionRepository>();
builder.Services.AddScoped<ILectureForSubjectRepository, LectureForSubjectRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationTypeRepository, NotificationTypeRepository>();
builder.Services.AddScoped<IYearRepository, YearRepository>();
builder.Services.AddScoped<ITeachingRepository, TeachingRepository>();
builder.Services.AddScoped<ILevelRepository, LevelRepository>();
builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();
builder.Services.AddScoped<ISubjectsInMajorsLevelRepository, SubjectsInMajorsLevelRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ICollegeRepository, CollegeRepository>();
builder.Services.AddScoped<ITermRepository, TermRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
