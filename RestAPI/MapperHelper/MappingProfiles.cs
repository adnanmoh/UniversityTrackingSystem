using AutoMapper;
using RestAPI.Models;
using RestAPI.VMs;

namespace RestAPI.MapperHelper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SysUser, UserVM>();
            CreateMap<UserVM, SysUser>();
            CreateMap<Student, StudentVM>();
            CreateMap<Student, SearchStudent>();
            CreateMap<StudentVM, Student>();
            CreateMap<TermVM, Term>(); 
            CreateMap<Term, TermVM>();
            CreateMap<Teacher, SearchTeacher>();
            CreateMap<Teacher, TeacherVM>();
            CreateMap<TeacherVM, Teacher>();
            CreateMap<Subject, SubjectVM>();
            CreateMap<Subject, SearchSubject>();
            CreateMap<SearchSubject, Subject>();
            CreateMap<SubjectVM, Subject>();
            CreateMap<Attendance, AttendanceVM>();
            CreateMap<AttendanceVM, Attendance>();
            CreateMap<StudentSchedule, StudentScheduleVM>();
            CreateMap<StudentSchedule, SearchStudentSchedule>();
            CreateMap<StudentScheduleVM, StudentSchedule>();
            CreateMap<TeacherSchedule, TeacherScheduleVM>();
            CreateMap<TeacherSchedule, SearchTeacherSchedule>();
            CreateMap<TeacherScheduleVM, TeacherSchedule>();
            CreateMap<Group, GroupVM>();
            CreateMap<GroupVM, Group>();
            CreateMap<Group, SearchGroup>();
            CreateMap<Lecture, LectureVM>();
            CreateMap<LectureVM, Lecture>();
            CreateMap<Major, MajorVM>();
            CreateMap<MajorVM, Major>();
            CreateMap<Level, LevelVM>();
            CreateMap<LevelVM, Level>();
            CreateMap<Assignment, AssignmentVM>();
            CreateMap<AssignmentVM, Assignment>();
            CreateMap<AssignmentSolution, AssignmentSolutionVM>();
            CreateMap < AssignmentSolutionVM, AssignmentSolution>();
            CreateMap<LectureForSubject, LectureForSubjectVM>();
            CreateMap<Grade, GradeVM>();
            CreateMap<GradeVM, Grade>();
            CreateMap<Teaching, TeachingVM>();
            CreateMap<TeachingVM, Teaching>();
            CreateMap<Year, YearVM>();
            CreateMap<YearVM, Year>();
            CreateMap<NotificationType, NotificationTypeVM>();
            CreateMap<Notification, NotificationVM>();
            CreateMap<NotificationVM, Notification>();
            CreateMap<SubjectsInMajorsLevel, SubjectsInMajorsLevelVM>();
            CreateMap<SubjectsInMajorsLevelVM, SubjectsInMajorsLevel>();
            CreateMap<Course, CourseVM>();
            CreateMap<CourseVM, Course>();
            CreateMap<Attachment, AttachmentVM>();
            CreateMap<AttachmentVM, Attachment>();
            CreateMap<CollegeVM, College>();
            CreateMap<College, CollegeVM>();
        }
    }
}
