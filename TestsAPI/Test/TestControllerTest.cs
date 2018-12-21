using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using TestsAPI.Controllers;
using TestsAPI.Models;

namespace TestsAPI.Test
{
    [TestFixture]
    public class TestControllerTest 
    {
        private TestController Controller { get; set; }

        [SetUp]
        public void SetUp()
        {
            Controller = new TestController();
        }

        [TestCase(null)]
        [TestCase("")]
        public void GetLikeFirstNameOrLastname_QueryNullOrEmpty_ReturnsEmptyList(string query)
        {
            var response = Controller.GetLikeFirstNameOrLastname(query) as OkNegotiatedContentResult<IEnumerable<Person>>;

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(0, response.Content.Count());
        }

        [TestCase("LLL", ExpectedResult = 3)]
        [TestCase("lll", ExpectedResult = 3)]
        public int GetLikeFirstNameOrLastname_ValidQuery_ReturnsListCorrectly(string query)
        {
            var response = Controller.GetLikeFirstNameOrLastname(query) as OkNegotiatedContentResult<IEnumerable<Person>>;

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Content);
            return response.Content.Count();
        }
    }
}
