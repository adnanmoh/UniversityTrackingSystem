using RestAPI.Interfaces;

namespace RestAPI.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IAssignmentRepository assignmentRepository;
        private readonly IAssignmentSolutionRepository assignmentSolutionRepository;
        private readonly IAttendanceRepository attendanceRepository;
        private readonly IGradeRepository gradeRepository;
        private readonly IGroupRepository groupRepository;
        private readonly ILectureForSubjectRepository lectureForSubjectRepository;
        private readonly ILectureRepository lectureRepository;
        private readonly IMajorRepository majorRepository;
        private readonly INotificationRepository notificationRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IStudentScheduleRepository studentScheduleRepository;
        private readonly ISubjectRepository subjectRepository;
        private readonly ITeacherRepository teacherRepository;
        private readonly ITeacherScheduleRepository teacherScheduleRepository;
        private readonly ITeachingRepository teachingRepository;
        private readonly INotificationTypeRepository notificationTypeRepository;
        private readonly IYearRepository yearRepository;
        private readonly ILevelRepository levelRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IAttachmentRepository attachmentRepository;
        private readonly ICollegeRepository collegeRepository;
        private readonly ITermRepository termRepository;
        private readonly ISubjectsInMajorsLevelRepository subjectsInMajorsLevelRepository;

        public RepositoryManager(
            IAssignmentRepository assignmentRepository,
            IAssignmentSolutionRepository assignmentSolutionRepository,
            IAttendanceRepository attendanceRepository,
            IGradeRepository gradeRepository,
            IGroupRepository groupRepository,
            ILectureForSubjectRepository lectureForSubjectRepository,
            ILectureRepository lectureRepository,
            IMajorRepository majorRepository,
            INotificationRepository notificationRepository,
            IStudentRepository studentRepository,
            IStudentScheduleRepository studentScheduleRepository,
            ISubjectRepository subjectRepository,
            ITeacherRepository teacherRepository,
            ITeacherScheduleRepository teacherScheduleRepository,
            ITeachingRepository teachingRepository,
            INotificationTypeRepository notificationTypeRepository,
            IYearRepository yearRepository,
            ILevelRepository levelRepository,
            ICourseRepository courseRepository,
            IAttachmentRepository attachmentRepository,
            ICollegeRepository collegeRepository,
            ITermRepository termRepository,
            ISubjectsInMajorsLevelRepository subjectsInMajorsLevelRepository

            )
        {
            this.assignmentRepository = assignmentRepository;
            this.assignmentSolutionRepository = assignmentSolutionRepository;
            this.attendanceRepository = attendanceRepository;
            this.gradeRepository = gradeRepository;
            this.groupRepository = groupRepository;
            this.lectureForSubjectRepository = lectureForSubjectRepository;
            this.lectureRepository = lectureRepository;
            this.majorRepository = majorRepository;
            this.notificationRepository = notificationRepository;
            this.studentRepository = studentRepository;
            this.studentScheduleRepository = studentScheduleRepository;
            this.subjectRepository = subjectRepository;
            this.teacherRepository = teacherRepository;
            this.teacherScheduleRepository = teacherScheduleRepository;
            this.teachingRepository = teachingRepository;
            this.notificationTypeRepository = notificationTypeRepository;
            this.yearRepository = yearRepository;
            this.levelRepository = levelRepository;
            this.courseRepository = courseRepository;
            this.attachmentRepository = attachmentRepository;
            this.collegeRepository = collegeRepository;
            this.termRepository = termRepository;
            this.subjectsInMajorsLevelRepository = subjectsInMajorsLevelRepository;
        }
        public IAssignmentRepository AssignmentRepository => assignmentRepository;

        public IAssignmentSolutionRepository AssignmentSolutionRepository => assignmentSolutionRepository;

        public IAttendanceRepository AttendanceRepository => attendanceRepository;

        public IGradeRepository GradeRepository => gradeRepository;

        public IGroupRepository GroupRepository => groupRepository;

        public ILectureRepository LectureRepository => lectureRepository;

        public ILectureForSubjectRepository LectureForSubjectRepository => lectureForSubjectRepository;

        public IMajorRepository MajorRepository => majorRepository;

        public INotificationRepository NotificationRepository => notificationRepository;

        public IStudentRepository StudentRepository => studentRepository;

        public IStudentScheduleRepository StudentScheduleRepository => studentScheduleRepository;

        public ISubjectRepository SubjectRepository => subjectRepository;

        public ITeacherRepository TeacherRepository => teacherRepository;

        public ITeacherScheduleRepository TeacherScheduleRepository => teacherScheduleRepository;

        public ITeachingRepository TeachingRepository => teachingRepository;

        public INotificationTypeRepository NotificationTypeRepository => notificationTypeRepository;

        public IYearRepository YearRepository => yearRepository;

        public ILevelRepository LevelRepository => levelRepository;

        public IAttachmentRepository AttachmentRepository => attachmentRepository;
        
        public ICourseRepository CourseRepository => courseRepository;

        public ICollegeRepository CollegeRepository => collegeRepository;

        public ITermRepository TermRepository => termRepository;

        public ISubjectsInMajorsLevelRepository SubjectsInMajorsLevelRepository => subjectsInMajorsLevelRepository;
    }
}
