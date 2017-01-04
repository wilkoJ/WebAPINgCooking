using System.Linq;

namespace WebAPINgCooking.Controllers
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T Get( int id );
        bool Add( T entity );
        bool Delete( int Id );
    }
}