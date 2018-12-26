using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieApi.Context;
using MovieApi.Controllers;
using MovieApi.Interfaces;
using MovieApi.Models;

namespace MovieApi.Tests.ActorController
{
    [TestClass]
    public class TestActorsController
    {
        ActorsController ac;

        List<Actor> actorListEmpty = new List<Actor>();

        IQueryable<Actor> actorList = new List<Actor> {
                        new Actor()
                        {
                            ActorId = 1,
                        },
                        new Actor()
                        {
                            ActorId = 2,
                        },
                          new Actor()
                        {
                            ActorId = 3,
                        }

                }.AsQueryable();


        [TestMethod]
        public void TestMethod1()
        {
            Mock<DbSet<Actor>> mockDbSet = new Mock<DbSet<Actor>>();
            
            mockDbSet.As<IQueryable<Actor>>().Setup(m => m.Provider).Returns(actorList.Provider);
            mockDbSet.As<IQueryable<Actor>>().Setup(m => m.Expression).Returns(actorList.Expression);
            mockDbSet.As<IQueryable<Actor>>().Setup(m => m.ElementType).Returns(actorList.ElementType);
            mockDbSet.As<IQueryable<Actor>>().Setup(m => m.GetEnumerator()).Returns(actorList.GetEnumerator());

            var mockContext = new Mock<MDbContext>();
            mockContext.Setup(set => set.Actors).Returns(mockDbSet.Object);
            
            ac = new ActorsController(mockContext.Object);
            var ret = ac.GetActor(1);
            var result = ret as OkNegotiatedContentResult<Actor>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.AreEqual(result.Content.ActorId, 1);
            
        }
    }
}
