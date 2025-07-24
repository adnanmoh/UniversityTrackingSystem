using RestAPI.Models;

namespace RestAPI.Interfaces
{
    public interface ILectureForSubjectRepository : IGenericRepository<LectureForSubject>
    {
        Task<ICollection<LectureForSubject>> GetAllLectureForOneSubject(int subjectID);
        Task<int> RemoveRange(List<LectureForSubject> subjects);
        Task<int> GetNumberOfLectureForOneSubject(int subjectID);

    }
}
