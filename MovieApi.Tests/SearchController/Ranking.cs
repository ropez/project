using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieApi.Context;
using MovieApi.Models;
using Moq;
using MovieApi.Controllers;
using System.Web.Http;
using System.Net;
using System.Data.Entity;
using MovieApi.Searchable;

namespace MovieApi.Tests.Tests
{
    [TestClass]
    public class UnitTest
    {
        Actor a1 = new Actor()
        {
            ActorId = 1,
            Name = "ABCD"
        };
        
        [TestMethod]
        public void TestCalcRangeEmptyQuery()
        {
            string query = "";

            Assert.AreEqual(SearchController.CalcRank(a1, query), 0);
        }

        [TestMethod]
        public void TestFullMatch()
        {
            string query = "ABCD";

            Assert.AreEqual(SearchController.CalcRank(a1, query), 100);
        }

        [TestMethod]
        public void TestFistHalfMatch()
        {
            string query = "AB";

            Assert.AreEqual(SearchController.CalcRank(a1, query), 50);
        }

        [TestMethod]
        public void TestSecondHalfMatch()
        {
            string query = "CD";
            Assert.AreEqual(SearchController.CalcRank(a1, query), 50);

        }

        [TestMethod]
        public void TestNoMatch()
        {
            string query = "OP";

            Assert.AreEqual(SearchController.CalcRank(a1, query), 0);
        }

        [TestMethod]
        public void TestLongerQuery()
        {
            string query = "ABOPU";

            Assert.AreEqual(SearchController.CalcRank(a1, query), 0);
        }

        [TestMethod]
        public void TesEmptyData()
        {

            Actor empty = new Actor() {
                Name = ""
             };  
            string query = "OP";

            Assert.AreEqual(SearchController.CalcRank(a1, query), 0);
        }
    }
}

