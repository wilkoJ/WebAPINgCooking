using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPINgCooking.Controllers;
using System.Net.Http;
using WebAPINgCooking;
using System.Web.Http;
using System.Linq;
using System.Net;
using Moq;
using System.Collections.Generic;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTestCommentController
    {
        [TestMethod]
        public void TestGetAllComment()
        {
            var repository = new Mock<IRepository<Comment>>();
            var comments = new List<Comment>();
            var c1 = new Comment() {comment="je suis un commentaire 1", mark = 3, recipeId=2, userId= 1, title="titre1"};
            var c2 = new Comment() {comment="je suis un commentaire 2", mark = 1, recipeId=2, userId= 1, title="titre2"};
            var c3 = new Comment() {comment="je suis un commentaire 3", mark = 4, recipeId=2, userId= 1, title="titre3"};
            comments.Add( c1 );
            comments.Add( c2 );
            comments.Add( c3 );
            repository.Setup( x => x.GetAll() ).Returns( comments.AsQueryable() ).Verifiable();
            var controller = new CommentsController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();
            IQueryable<Comment> s;
            Assert.IsTrue( response.TryGetContentValue<IQueryable<Comment>>( out s ) );
            Assert.AreEqual( comments.AsQueryable().Count(), s.Count() );
            Assert.AreEqual( comments.AsQueryable().First(), s.First() );
        }
        [TestMethod]
        public void TestPostComment()
        {
            var repository = new Mock<IRepository<Comment>>();
            var comment = new Comment() {comment="je suis un commentaire", mark = 3, recipeId=2, userId= 1, title="titre1"};
            repository.Setup( x => x.Add( comment ) ).Returns( true ).Verifiable();
            var controller = new CommentsController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Post(comment);
            Comment s;
            Assert.IsTrue( response.TryGetContentValue<Comment>( out s ) );
            Assert.AreEqual( comment, s );
            Assert.AreNotEqual( "titre2", s.title);
        }
    }
}
