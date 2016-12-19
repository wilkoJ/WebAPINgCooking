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
    public class UnitTestIngredientController
    {
        [TestMethod]
        public void TestGetIngredient()
        {
            var repository = new Mock<IRepository<Ingredient>>();
            var ingredient = new Ingredient() { ingredientId = 1, categoryId = 2, calories = 500, name="tomate"};
            repository.Setup( x => x.Get( 5 ) ).Returns( ingredient ).Verifiable();
            var controller = new IngredientsController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get(5);
            Ingredient s;
            Assert.IsTrue( response.TryGetContentValue<Ingredient>( out s ) );
            Assert.AreEqual( ingredient, s );
            Assert.AreNotEqual( 10, s.ingredientId );
        }
        [TestMethod]
        public void TestGetAllIngredient()
        {
            var repository = new Mock<IRepository<Ingredient>>();
            var ingredients = new List<Ingredient>();
            var r1 = new Ingredient() { ingredientId = 1, categoryId = 1, calories = 500,  name= "tomate"};
            var r2 = new Ingredient() { ingredientId = 2, categoryId = 2, calories = 500,  name= "ananas"};
            var r3 = new Ingredient() { ingredientId = 3, categoryId = 4, calories = 500,  name= "colin"};
            ingredients.Add( r1 );
            ingredients.Add( r2 );
            ingredients.Add( r3 );
            repository.Setup( x => x.GetAll() ).Returns( ingredients.AsQueryable() ).Verifiable();
            var controller = new IngredientsController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Get();
            IQueryable<Ingredient> s;
            Assert.IsTrue( response.TryGetContentValue<IQueryable<Ingredient>>( out s ) );
            Assert.AreEqual( ingredients.AsQueryable().Count(), s.Count() );
            Assert.AreEqual( ingredients.AsQueryable().First(), s.First() );
        }
        [TestMethod]
        public void TestPostIngredient() {
            var repository = new Mock<IRepository<Ingredient>>();
            var ingredient = new Ingredient() { ingredientId = 1, categoryId = 2, calories = 500, name="tomate"};
            repository.Setup( x => x.Add( ingredient ) ).Returns( true ).Verifiable();
            var controller = new IngredientsController(repository.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var response = controller.Post(ingredient);
            Ingredient s;
            Assert.IsTrue( response.TryGetContentValue<Ingredient>( out s ) );
            Assert.AreEqual( ingredient, s );
            Assert.AreNotEqual( 10, s.ingredientId );
        }
    }
}
