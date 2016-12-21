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
    public class UnitTestCategoryRecipeController
    {
        [TestMethod]
        public void TestGetCategoryRecipe()
        {
            var repository = new Mock<IRepository<CategoryRecipe>>();
            var categoryRecipe = new CategoryRecipe()  { categoryId = 1, name= "fromage"};
            repository.Setup( x => x.Get( 5 ) ).Returns( categoryRecipe ).Verifiable();
            var controller = new CategoryRecipesController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get(5);
            CategoryRecipe s;
            Assert.IsTrue( response.TryGetContentValue<CategoryRecipe>( out s ) );
            Assert.AreEqual( categoryRecipe, s );
            Assert.AreNotEqual( 10, s.categoryId );
        }
        [TestMethod]
        public void TestGetAllCategoryRecipe()
        {
            var repository = new Mock<IRepository<CategoryRecipe>>();
            var categoryRecipes = new List<CategoryRecipe>();
            var r1 = new CategoryRecipe() { categoryId = 1, name= "fromage"};
            var r2 = new CategoryRecipe() { categoryId = 2, name= "fruit"};
            var r3 = new CategoryRecipe() { categoryId = 3, name= "poisson"};
            categoryRecipes.Add( r1 );
            categoryRecipes.Add( r2 );
            categoryRecipes.Add( r3 );
            repository.Setup( x => x.GetAll() ).Returns( categoryRecipes.AsQueryable() ).Verifiable();
            var controller = new CategoryRecipesController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();
            IQueryable<CategoryRecipe> s;
            Assert.IsTrue( response.TryGetContentValue<IQueryable<CategoryRecipe>>( out s ) );
            Assert.AreEqual( categoryRecipes.AsQueryable().Count(), s.Count() );
            Assert.AreEqual( categoryRecipes.AsQueryable().First(), s.First() );
        }
        [TestMethod]
        public void TestPostCategoryRecipe()
        {
            var repository = new Mock<IRepository<CategoryRecipe>>();
            var categoryRecipe = new CategoryRecipe()  { categoryId = 1, name= "fromage"};
            repository.Setup( x => x.Add( categoryRecipe ) ).Returns( true ).Verifiable();
            var controller = new CategoryRecipesController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Post(categoryRecipe);
            CategoryRecipe s;
            Assert.IsTrue( response.TryGetContentValue<CategoryRecipe>( out s ) );
            Assert.AreEqual( categoryRecipe, s );
            Assert.AreNotEqual( 10, s.categoryId );
        }
    }
}
