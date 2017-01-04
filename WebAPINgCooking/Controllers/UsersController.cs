using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPINgCooking.Controllers
{
    public class UsersController : ApiController
    {
        private IRepository<User> _repo;
        public UsersController( IRepository<User> repo)
        {
            _repo = repo;
        }
        // GET: api/Users
        public HttpResponseMessage Get()
        {
            IQueryable<User> res = _repo.GetAll();
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Get( int id )
        {
            User res = _repo.Get(id);
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Post( User entity )
        {
            var res = _repo.Add( entity );
            if( !res )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( HttpStatusCode.Created, entity );
        }

        public HttpResponseMessage Delete( int Id )
        { 
            var res = _repo.Delete( Id );
            if (!res)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            return Request.CreateResponse(HttpStatusCode.Created, Id);
        }
    }
}