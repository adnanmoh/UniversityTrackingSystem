namespace RestAPI.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();
        IQueryable<T> GetAllIQueryable();
        Task<T> GetObjById(int id);
        Task<T> GetObjById(params object[] keys) ;
        Task<bool> ObjExists(int id);
        Task<bool> ObjExists(params object[] keys);

        Task<T> Add(T obj);
        Task<int> SaveChangesAsync();

        T Edit(T obj);
        Task<bool> Remove(T obj);
        /*ICollection<T> EditRange(int start, int end);*/


    }
}
