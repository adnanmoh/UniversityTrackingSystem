using Microsoft.EntityFrameworkCore;
using RestAPI.Data;
using RestAPI.Interfaces;
using System.Linq;

namespace RestAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly UAppContext context;

        public GenericRepository(UAppContext context) 
        {
            this.context = context;
        }

        public async Task<T> Add(T obj)
        {
            try
            {
                var res =await context.Set<T>().AddAsync(obj);
                await SaveChangesAsync();
                return res.Entity;
            }
            catch 
            {

                return default(T);
            }
        }
        public async Task<T> GetObjById(int id)
        {
            try
            {
                var res = await context.Set<T>().FindAsync(id);
                context.ChangeTracker.Clear();
                return res;
            }
            catch 
            {

                return default(T);
            }

        }


        public async Task<ICollection<T>> GetAll()
        {

            return await context.Set<T>().ToListAsync();
                
           
        }

        public async Task<bool> ObjExists(int id)
        {
            var obj = await context.Set<T>().FindAsync(id);
            if (obj == null)
            {
                return false;
            }

            return true;
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await context.SaveChangesAsync();
            }
            catch 
            {

                return 0;
            } 
        }

        

        public  T Edit(T obj)
        {
            try
            {
                var res =  context.Set<T>().Update(obj);
                SaveChangesAsync();
                return res.Entity;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return default(T);
            }
        }



        public async Task<T> GetObjById(params object[] keys)
        {
            try
            {
                var res = await context.Set<T>().FindAsync(keys);
                return res;
            }
            catch
            {

                return default(T);
            }
        }

        public async Task<bool> ObjExists(params object[] keys)
        {
            var obj = await context.Set<T>().FindAsync(keys);
            if (obj == null)
            {
                return false;
            }

            return true;
        }

        public  IQueryable<T> GetAllIQueryable()
        {
            return  context.Set<T>().AsQueryable();
        }

        public async Task<bool> Remove(T obj)
        {
            var res =  context.Set<T>().Remove(obj);
            var Sres = await SaveChangesAsync();
            if (res == null && Sres <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
