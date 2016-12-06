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
            /*string path = string.Format("{0}{1}",System.AppDomain.CurrentDomain.BaseDirectory,@"ngCooking-master/json/recettes.json");
            using( StreamReader file = File.OpenText( path ) )
            {
                JsonSerializer serializer = new JsonSerializer();
                IList<Recipe> CI = (IList<Recipe>)serializer.Deserialize(file, typeof(IList<Recipe>));
                foreach( var c in CI )
                {
                    PostRecipe( c );
                }
            }*/
        }
        // GET: api/Recipes
        public IQueryable<Recipe> Get()
        {
            return _repo.GetAll();
        }
        public void Post( Recipe entity )
        {
            _repo.Add( entity );
        }
        public void Delete( int Id )
        {
            _repo.Delete( Id );
        }
    }
}