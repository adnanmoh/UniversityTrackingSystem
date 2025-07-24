using RestAPI.Data;
using RestAPI.Interfaces;
using RestAPI.Models;

namespace RestAPI.Repository
{
    public class LectureRepository : GenericRepository<Lecture>, ILectureRepository
    {
        private readonly UAppContext context;

        public LectureRepository(UAppContext context) : base(context)
        {
            this.context = context;
        }

    }
}
