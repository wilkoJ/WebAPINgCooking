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
    public class UsersController : ApiController
    {
        private IRepository<User> _repo;
        public UsersController( IRepository<User> repo)
        {
            _repo = repo;
            /* string path = string.Format("{0}{1}",System.AppDomain.CurrentDomain.BaseDirectory,@"ngCooking-master/json/communaute.json");
            using( StreamReader file = File.OpenText( path ) )
            {
                JsonSerializer serializer = new JsonSerializer();
                IList<User> users = (IList<User>)serializer.Deserialize(file, typeof(IList<User>));
                foreach (var u in users)
                {
                    PostUser( u );
                }
            }*/
            
        }
        // GET: api/Users
        public HttpResponseMessage Get()
        {
            IQueryable<User> res = _repo.GetAll();
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Get( int id )
        {
            User res = _repo.Get(id);
            if( res == null )
                return Request.CreateResponse( HttpStatusCode.NotFound );
            return Request.CreateResponse( res );
        }
        public HttpResponseMessage Post( User entity )
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