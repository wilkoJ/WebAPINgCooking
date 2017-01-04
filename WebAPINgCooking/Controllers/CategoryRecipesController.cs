using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPINgCooking.Controllers
{
    public class CategoryRecipesController : ApiController
    {
        private IRepository<CategoryRecipe> _repo;

        // GET: api/CategoryRecipes
        public CategoryRecipesController( IRepository<CategoryRecipe> repo )
        {
            _repo = repo;

        }
        // GET: api/Comments
        public HttpResponseMessage Get()
        {
            IQueryable<CategoryRecipe> res = _repo.GetAll();
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Get( int id )
        {
            CategoryRecipe res = _repo.Get(id);
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Post( CategoryRecipe entity )
        {
            var res = _repo.Add( entity );
            if( !res )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( HttpStatusCode.Created, entity );
        }
        public void Delete( int Id )
        {
            _repo.Delete( Id );
        }
    }
}