using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPINgCooking.Controllers
{
    public class CategoryIngredientsController : ApiController
    {
        private IRepository<CategoryIngredient> _repo;

        public CategoryIngredientsController( IRepository<CategoryIngredient> repo)
        {
            _repo = repo;

        }
        // GET: api/CategoryIngredients
        public HttpResponseMessage Get()
        {
            IQueryable<CategoryIngredient> res = _repo.GetAll();
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Get( int id )
        {
            CategoryIngredient res = _repo.Get(id);
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Post( CategoryIngredient entity )
        {
            var res = _repo.Add( entity );
            if( !res )
                return Request.CreateResponse( HttpStatusCode.BadRequest);
            return Request.CreateResponse( HttpStatusCode.Created, entity );
        }
        public void Delete( int Id )
        {
            _repo.Delete( Id );
        }
    }
}