using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPINgCooking;

namespace WebAPINgCooking.Controllers
{
    public class CommentsController : ApiController
    {
        private IRepository<Comment> _repo;

        public CommentsController( IRepository<Comment> repo )
        {
            _repo = repo;
        }
        // GET: api/Comments
        public IQueryable<Comment> Get()
        {
            return _repo.GetAll();
        }
        public HttpResponseMessage Post( Comment entity )
        {
            _repo.Add( entity );
            return Request.CreateResponse( HttpStatusCode.OK, new
            {
                entity = entity
            } );
        }
        public void Delete( int Id )
        {
            _repo.Delete( Id );
        }

    }
}