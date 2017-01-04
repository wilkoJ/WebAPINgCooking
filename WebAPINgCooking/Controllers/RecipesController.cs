using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPINgCooking.Controllers
{
    public class RecipesController : ApiController
    {
        private IRepository<Recipe> _repo;
        public RecipesController( IRepository<Recipe> repo)
        {
            _repo = repo;
        }
        // GET: api/Recipes
        public HttpResponseMessage Get()
        {
            IQueryable<Recipe> res = _repo.GetAll();
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Get( int id )
        {
            Recipe res = _repo.Get(id);
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Post( Recipe entity )
        {
            var res = _repo.Add( entity );
            if( !res && true)
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( HttpStatusCode.Created, entity );
        }
        public void Delete( int Id )
        {
            _repo.Delete( Id );
        }
    }
}