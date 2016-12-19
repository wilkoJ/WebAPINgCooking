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
    public class RecipesController : ApiController
    {
        private IRepository<Recipe> _repo;
        public RecipesController( IRepository<Recipe> repo)
        {
            _repo = repo;
            /*string path = string.Format("{0}{1}",System.AppDomain.CurrentDomain.BaseDirectory,@"json/recettes.json");
            using( StreamReader file = File.OpenText( path ) )
            {
                JsonSerializer serializer = new JsonSerializer();
                IList<Recipe> CI = (IList<Recipe>)serializer.Deserialize(file, typeof(IList<Recipe>));
                foreach( var c in CI )
                {
                    this.Post( c );
                }
            }*/
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