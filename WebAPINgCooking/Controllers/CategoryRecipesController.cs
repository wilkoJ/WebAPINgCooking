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
        public IQueryable<CategoryRecipe> Get()
        {
            return _repo.GetAll();
        }
        public void Post( CategoryRecipe entity )
        {
            _repo.Add( entity );
        }
        public void Delete( int Id )
        {
            _repo.Delete( Id );
        }
    }
}