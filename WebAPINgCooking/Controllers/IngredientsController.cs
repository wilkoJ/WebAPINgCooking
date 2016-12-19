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
    public class IngredientsController : ApiController
    {
        private IRepository<Ingredient> _repo;
        public IngredientsController( IRepository<Ingredient> repo)
        {
            _repo = repo;
            /*string path = string.Format("{0}{1}",System.AppDomain.CurrentDomain.BaseDirectory,@"json/ingredients.json");
            using( StreamReader file = File.OpenText( path ) )
            {
                JsonSerializer serializer = new JsonSerializer();
                IList<Ingredient> CI = (IList<Ingredient>)serializer.Deserialize(file, typeof(IList<Ingredient>));
                foreach( var c in CI )
                {
                    Post( c );
                }
            }*/
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