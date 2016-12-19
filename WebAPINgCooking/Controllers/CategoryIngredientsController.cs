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
    public class CategoryIngredientsController : ApiController
    {
        private IRepository<CategoryIngredient> _repo;

        public CategoryIngredientsController( IRepository<CategoryIngredient> repo)
        {
            _repo = repo;
            /*string path = string.Format("{0}{1}",System.AppDomain.CurrentDomain.BaseDirectory,@"ngCooking-master/json/categories.json");
            using( StreamReader file = File.OpenText( path ) )
            {
                JsonSerializer serializer = new JsonSerializer();
                IList<CategoryIngredient> CI = (IList<CategoryIngredient>)serializer.Deserialize(file, typeof(IList<CategoryIngredient>));
                foreach( var c in CI )
                {
                    PostCategoryIngredient( c );
                }
            }*/
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
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( HttpStatusCode.Created, entity );
        }
        public void Delete( int Id )
        {
            _repo.Delete( Id );
        }
    }
}