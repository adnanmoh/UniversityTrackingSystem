namespace RestAPI.Interfaces
{
    public interface IRepositoryManager
    {
        IAssignmentRepository AssignmentRepository { get; }
        IAssignmentSolutionRepository AssignmentSolutionRepository { get; }
        IAttendanceRepository AttendanceRepository { get; }
        IGradeRepository GradeRepository { get; }
        IGroupRepository GroupRepository { get; }
        ILectureRepository LectureRepository { get; }
        ILectureForSubjectRepository LectureForSubjectRepository { get; }
        IMajorRepository MajorRepository { get; }
        INotificationRepository NotificationRepository { get; }
        INotificationTypeRepository NotificationTypeRepository { get; }
        IStudentRepository StudentRepository { get; }
        IStudentScheduleRepository StudentScheduleRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        ITeacherRepository TeacherRepository { get; }
        ITeacherScheduleRepository TeacherScheduleRepository { get; }
        ITeachingRepository TeachingRepository { get; }
        IYearRepository YearRepository { get; }
        ILevelRepository LevelRepository { get; }
        IAttachmentRepository AttachmentRepository { get; }
        ISubjectsInMajorsLevelRepository SubjectsInMajorsLevelRepository { get; }
        ICourseRepository CourseRepository { get; }
        ICollegeRepository CollegeRepository { get; }
        ITermRepository TermRepository { get; }
    }
}
