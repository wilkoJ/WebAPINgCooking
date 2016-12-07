using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

        public void Add( T entity )
        {
            if( entity != null )
            {
                _dbSet.Add( entity );
                _db.SaveChanges();
            }
        }
        public void Delete( int Id )
        {
            T entity;
            if ((entity = _dbSet.Find( Id )) != null)
                _dbSet.Remove( entity );
        }
    }
}