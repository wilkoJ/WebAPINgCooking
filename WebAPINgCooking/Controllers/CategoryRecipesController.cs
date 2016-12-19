using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPINgCooking;

namespace WebAPINgCooking.Controllers
{
    public class CategoryRecipesController : ApiController
    {
        private IRepository<CategoryRecipe> _repo;

        // GET: api/CategoryRecipes
        public CategoryRecipesController( IRepository<CategoryRecipe> repo )
        {
            _repo = repo;
            /*string path = string.Format("{0}{1}",System.AppDomain.CurrentDomain.BaseDirectory,@"ngCooking-master/json/categories.json");
            using( StreamReader file = File.OpenText( path ) )
            {
                JsonSerializer serializer = new JsonSerializer();
                IList<CategoryRecipe> CI = (IList<CategoryRecipe>)serializer.Deserialize(file, typeof(IList<CategoryRecipe>));
                foreach( var c in CI )
                {
                    PostCategoryRecipe( c );
                }
            }*/
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