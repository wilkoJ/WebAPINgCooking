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
    public class UnitTestCategoryIngredientController
    {
        [TestMethod]
        public void TestGetCategoryIngredient()
        {
            var repository = new Mock<IRepository<CategoryIngredient>>();
            var categoryIngredient = new CategoryIngredient()  { categoryId = 1, name= "fromage"};
            repository.Setup( x => x.Get( 5 ) ).Returns( categoryIngredient ).Verifiable();
            var controller = new CategoryIngredientsController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get(5);
            CategoryIngredient s;
            Assert.IsTrue( response.TryGetContentValue<CategoryIngredient>( out s ) );
            Assert.AreEqual( categoryIngredient, s );
            Assert.AreNotEqual( 10, s.categoryId );
        }
        [TestMethod]
        public void TestGetAllCategoryIngredient()
        {
            var repository = new Mock<IRepository<CategoryIngredient>>();
            var categoryIngredients = new List<CategoryIngredient>();
            var r1 = new CategoryIngredient() { categoryId = 1, name= "fromage"};
            var r2 = new CategoryIngredient() { categoryId = 2, name= "fruit"};
            var r3 = new CategoryIngredient() { categoryId = 3, name= "poisson"};
            categoryIngredients.Add( r1 );
            categoryIngredients.Add( r2 );
            categoryIngredients.Add( r3 );
            repository.Setup( x => x.GetAll() ).Returns( categoryIngredients.AsQueryable() ).Verifiable();
            var controller = new CategoryIngredientsController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();
            IQueryable<CategoryIngredient> s;
            Assert.IsTrue( response.TryGetContentValue<IQueryable<CategoryIngredient>>( out s ) );
            Assert.AreEqual( categoryIngredients.AsQueryable().Count(), s.Count() );
            Assert.AreEqual( categoryIngredients.AsQueryable().First(), s.First() );
        }
        [TestMethod]
        public void TestPostCategoryIngredient()
        {
            var repository = new Mock<IRepository<CategoryIngredient>>();
            var categoryIngredient = new CategoryIngredient()  { categoryId = 1, name= "fromage"};
            repository.Setup( x => x.Add( categoryIngredient ) ).Returns( true ).Verifiable();
            var controller = new CategoryIngredientsController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Post(categoryIngredient);
            CategoryIngredient s;
            Assert.IsTrue( response.TryGetContentValue<CategoryIngredient>( out s ) );
            Assert.AreEqual( categoryIngredient, s );
            Assert.AreNotEqual( 10, s.categoryId );
        }
    }
}
