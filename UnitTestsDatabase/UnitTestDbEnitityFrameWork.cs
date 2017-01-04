using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPINgCooking;
using WebAPINgCooking.Controllers;

namespace UnitTestsDatabase
{
    [TestClass]
    public class UnitTestDbEnitityFrameWork
    {
        private ngCookingContext dbContext = new ngCookingContext();
        [TestMethod]
        public void TestPostInvalidValues()
        {
            var repositoryU = new Repository<User>(dbContext);
            var repositoryR = new Repository<Recipe>(dbContext);
            var repositoryC = new Repository<Comment>(dbContext);
            var users = Builder<User>.CreateListOfSize(5).Build();
            var recipes = Builder<Recipe>.CreateListOfSize(5).Build();
            var coms = Builder<Comment>.CreateListOfSize(5).Build();
            int i = 0;
            foreach (var c in users)
            {
               c .userId = 0;
                var res = repositoryU.Add(c);
                Assert.AreEqual(false, res);
            }
            foreach (var c in recipes)
            {
                c.recipeId = 0;
                var res = repositoryR.Add(c);
                Assert.AreEqual(false, res);
            }


            foreach (var c in recipes) { 
                var res = repositoryR.Delete(c.userId);
                Assert.AreEqual(false, res);
            }
            foreach (var c in users)
            {
                var res = repositoryU.Delete(c.userId);
                Assert.AreEqual(false, res);
            }
            foreach (var c in coms){
                var res = repositoryC.Delete(c.userId);
                Assert.AreEqual(false, res);
            }
            foreach (var c in coms) 
            {
                var res = repositoryC.Add(c);
                Assert.AreEqual(false, res);
            }
            dbContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('User', RESEED, 0)");
            dbContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Comment', RESEED, 0)");
            dbContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Recipe', RESEED, 0)");
        }
    }
}
