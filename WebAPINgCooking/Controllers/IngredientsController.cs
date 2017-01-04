using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPINgCooking.Controllers
{
    public class IngredientsController : ApiController
    {
        private IRepository<Ingredient> _repo;
        public IngredientsController( IRepository<Ingredient> repo)
        {
            _repo = repo;

        }
        // GET: api/Ingredients
        public HttpResponseMessage Get()
        {
            IQueryable<Ingredient> res = _repo.GetAll();
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Get( int id )
        {
            Ingredient res = _repo.Get(id);
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Post( Ingredient entity )
        {
            var res = _repo.Add( entity );
            if( !res )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( HttpStatusCode.Created, entity );
        }
        public void Delete( int Id)
        {
            _repo.Delete( Id );
        }
    }
}