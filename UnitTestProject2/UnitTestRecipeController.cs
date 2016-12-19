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
    public class UnitTestRecipeController
    {
        [TestMethod]
        public void GetRecipe()
        {
            var repository = new Mock<IRepository<Recipe>>();
            var recipe = new Recipe() { recipeId = 1, userId = 1, categoryId = 2, calories = 500,  preparation= "zazaaza"};
            repository.Setup( x => x.Get( 5 ) ).Returns( recipe ).Verifiable();
            var controller = new RecipesController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get(5);
            Recipe s;
            Assert.IsTrue( response.TryGetContentValue<Recipe>( out s ) );
            Assert.AreEqual( recipe, s );
            Assert.AreNotEqual( 10, s.recipeId );
        }
        [TestMethod]
        public void GetAllRecipe()
        {
            var repository = new Mock<IRepository<Recipe>>();
            var recipes = new List<Recipe>();
            var r1 = new Recipe() { recipeId = 1, userId = 1, categoryId = 2, calories = 500,  preparation= "zazaaza"};
            var r2 = new Recipe() { recipeId = 2, userId = 3, categoryId = 2, calories = 500,  preparation= "zazaaza"};
            var r3 = new Recipe() { recipeId = 3, userId = 2, categoryId = 2, calories = 500,  preparation= "zazaaza"};
            recipes.Add( r1 );
            recipes.Add( r2 );
            recipes.Add( r3 );
            repository.Setup( x => x.GetAll() ).Returns( recipes.AsQueryable() ).Verifiable();
            var controller = new RecipesController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();
            IQueryable<Recipe> s;
            Assert.IsTrue( response.TryGetContentValue<IQueryable<Recipe>>( out s ) );
            Assert.AreEqual( recipes.AsQueryable().Count(), s.Count() );
            Assert.AreEqual( recipes.AsQueryable().First(), s.First() );
        }
        [TestMethod]
        public void TestPostRecipe()
        {
            var repository = new Mock<IRepository<Recipe>>();
            var recipe = new Recipe() { recipeId = 1, userId = 1, categoryId = 2, calories = 500,  preparation= "zazaaza"};
            repository.Setup( x => x.Add( recipe ) ).Returns( true ).Verifiable();
            var controller = new RecipesController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Post(recipe);
            Recipe s;
            Assert.IsTrue( response.TryGetContentValue<Recipe>( out s ) );
            Assert.AreEqual( recipe, s );
            Assert.AreNotEqual( 10, s.recipeId );
        }
    }
}
