using System;
using System.Data.Entity;
using System.Linq;

namespace WebAPINgCooking.Controllers
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private ngCookingContext _db;
        private DbSet<T> _dbSet;

        public Repository( ngCookingContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T Get(int id)
        {
            return _dbSet.Find( id );
        }
        public bool Add( T entity )
        {
            bool res;
            try
            {
                _dbSet.Add( entity );
                _db.SaveChanges();
                res = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                res = false;
            }
            return res;
        }
        public bool Delete( int Id )
        {
            bool res;
            try
            {
                T entity;
                if ((entity = _dbSet.Find(Id)) != null)
                    _dbSet.Remove(entity);
                _db.SaveChanges();
                res = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                res = false;
            }
            return res;
        }
    }
}