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
    public class UnitTestUserController
    {
        [TestMethod]
        public void TestGetUser()
        {
            var repository = new Mock<IRepository<User>>();
            var user = new User() { userId = 5, bio = "j'etre wilko", birth = 1994, city="Paris",email="aa@titi.mail", password="pwd" };
            repository.Setup(x => x.Get(5)).Returns(user).Verifiable();
            var controller = new UsersController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get(5);
            User s;
            Assert.IsTrue( response.TryGetContentValue<User>( out s ) );
            Assert.AreEqual( user, s);
            Assert.AreNotEqual( 10, s.userId );
        }
        [TestMethod]
        public void TestGetAllUser()
        {
            var repository = new Mock<IRepository<User>>();
            var users = new List<User>();
            var u1 = new User(){ userId = 1, bio = "j'etre wilko", birth = 1994, city = "Paris",email = "aa@titi.mail", password = "pwd" };
            var u2 = new User(){ userId = 2, bio = "j'etre gerard", birth = 1993, city = "Londres",email = "bb@titi.mail", password = "pwd" };
            var u3 = new User(){ userId = 3, bio = "j'etre jean-eudes", birth = 1992, city = "New-York",email = "cc@titi.mail", password = "pwd" };
            users.Add(u1);
            users.Add( u2 );
            users.Add( u3 );
            repository.Setup( x => x.GetAll() ).Returns( users.AsQueryable() ).Verifiable();
            var controller = new UsersController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();
            IQueryable<User> s;
            Assert.IsTrue( response.TryGetContentValue<IQueryable<User>>( out s ) );
            Assert.AreEqual( users.AsQueryable().Count(), s.Count() );
            Assert.AreEqual( users.AsQueryable().First(), s.First() );
        }
        [TestMethod]
        public void TestPostUser()
        {
            var repository = new Mock<IRepository<User>>();
            var user = new User() { userId = 5, bio = "j'etre wilko", birth = 1994, city="Paris",email="aa@titi.mail", password="pwd" };
            repository.Setup( x => x.Add( user ) ).Returns( true ).Verifiable();
            var controller = new UsersController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Post(user);
            User s;
            Assert.IsTrue( response.TryGetContentValue<User>( out s ) );
            Assert.AreEqual( user, s );
            Assert.AreNotEqual( 10, s.userId );
        }
    }
}
