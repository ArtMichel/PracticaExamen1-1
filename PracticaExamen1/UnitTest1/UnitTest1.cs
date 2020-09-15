using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticaExamen1.Controllers;
using PracticaExamen1.Models;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        //GET
        [TestMethod]
        public void TestGet()
        {
            //arrange
            MichelsController controller = new MichelsController();

            //act
            var result = controller.GetMichels();

            //assert
            Assert.IsNotNull(result);
        }

        //POST
        [TestMethod]
        public void TestPost()
        {
            //arrange
            MichelsController controller = new MichelsController();
            Michel expected = new Michel() 
            {
                MichelID = 10,
                FriendofMichel = "Bob Smith",
                Place = CategoryType.Urubo,
                Email = "123@hotmail.com",
                Birthday = DateTime.Today
            };

            //act
            var actionResult = controller.PostMichel(expected);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Michel>;

            //assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(expected.FriendofMichel, createdResult.Content.FriendofMichel);
        }

        //PUT
        [TestMethod]
        public void TestPut()
        {
            //arrange
            MichelsController controller = new MichelsController();
            Michel expected = new Michel()
            {
                MichelID = 10,
                FriendofMichel = "Bob Smith",
                Place = CategoryType.Urubo,
                Email = "123@hotmail.com",
                Birthday = DateTime.Today
            };

            //act
            IHttpActionResult actionResult = controller.PostMichel(expected);
            var result = controller.PutMichel(expected.MichelID, expected) as StatusCodeResult;

            //assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        //DELETE
        [TestMethod]
        public void TestDelete()
        {
            //arrange
            MichelsController controller = new MichelsController();
            Michel expected = new Michel()
            {
                MichelID = 10,
                FriendofMichel = "Bob Smith",
                Place = CategoryType.Urubo,
                Email = "123@hotmail.com",
                Birthday = DateTime.Today
            };

            //act
            IHttpActionResult actionResult = controller.PostMichel(expected);
            IHttpActionResult actionDelete = controller.DeleteMichel(expected.MichelID);

            //assert
            Assert.IsInstanceOfType(actionDelete, typeof(OkNegotiatedContentResult<Michel>));

        }

    }
}
