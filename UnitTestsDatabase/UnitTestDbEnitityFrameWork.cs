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
            foreach (var c in users)
            {
               c .userId = 0;
                var res = repositoryU.Add(c);
                Assert.AreNotEqual(false, res);
            }
            foreach (var c in users)
            {
                var res = repositoryU.Delete(c.userId);
                Assert.AreNotEqual(false, res);
            }
            dbContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Users', RESEED, 0)");
            dbContext.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Recipe', RESEED, 0)");
        }
    }
}
