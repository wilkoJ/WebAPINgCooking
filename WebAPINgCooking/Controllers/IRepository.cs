using System.Linq;

namespace WebAPINgCooking.Controllers
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        void Add( T entity );
        void Delete( int Id );
    }
}