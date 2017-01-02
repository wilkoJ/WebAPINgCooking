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
                var res = repositoryU.Add(c);
                Assert.AreEqual(true, res);
            }
            //foreach (var c in recipes)
            //{
            //    var res = repositoryR.Add(c);
            //}
            //foreach ( var c in coms )
            //{
            //    var res = repositoryC.Add( c );
            //    Assert.AreEqual( false, res );
            //}
            foreach (var c in users)
            {
                var res =   repositoryU.Delete(c.userId);
                Assert.AreEqual(true, res);
            }
            //foreach (var c in recipes)
            //    repositoryR.Delete(c.userId);
            //foreach (var c in coms)
            //    repositoryC.Delete(c.userId);
        }
    }
}
