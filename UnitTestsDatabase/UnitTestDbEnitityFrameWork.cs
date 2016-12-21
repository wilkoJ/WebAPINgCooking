using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPINgCooking;
using WebAPINgCooking.Controllers;
using System.Collections.Generic;
using FizzWare.NBuilder;

namespace UnitTestsDatabase
{
    [TestClass]
    public class UnitTestDbEnitityFrameWork
    {
        private ngCookingContext dbContext = new ngCookingContext();
        [TestMethod]
        public void TestPostInvalidValues()
        {
            var repository = new Repository<Comment>(dbContext);
            var users = Builder<Comment>.CreateListOfSize(5).Build();
            foreach( var c in users )
            {
                var res = repository.Add( c );
                Assert.AreEqual( false, res );
            }
            /*foreach( var c in users )
                repository.Delete( c.userId );*/
        }
    }
}
