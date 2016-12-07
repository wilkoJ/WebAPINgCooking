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
        public IQueryable<User> GetUsers()
        {
            return _repo.GetAll();
        }
        public void Post( User entity )
        {
            _repo.Add( entity );
        }
        public void Delete( int Id )
        { 
            _repo.Delete( Id );
        }
    }
}