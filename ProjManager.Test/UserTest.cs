using NUnit.Framework;
using ProjManager.Data;
using ProjManagerSvc.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace ProjManager.Test
{
    [TestFixture]
    class UserTest
    {
        private readonly UserController usrSvc;

        public UserTest()
        {
            usrSvc = new UserController();
        }

        [Test]
        public void GetAllUserTest()
        {

            var response = usrSvc.GetAllUsers();
            List<USER> responseResult = ((OkNegotiatedContentResult<List<USER>>)response).Content;
            Assert.Greater(responseResult.Count, 0);
        }

        [Test]
        public void GetUserByIdTest()
        {
            USER expected = new USER
            {
                FirstName = "Nancy",
                LastName = "DJ",
                UserId = 1,
                EmployeeId = 395423,
                ProjectId = 1
            };
            var response = usrSvc.GetUserbyId(1);
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<USER>), response);
            USER responseResult = ((OkNegotiatedContentResult<USER>)response).Content;
            if (responseResult != null)
            {
                Assert.AreEqual(expected.FirstName, responseResult.FirstName);
                Assert.AreEqual(expected.LastName, responseResult.LastName);
                Assert.AreEqual(expected.EmployeeId, responseResult.EmployeeId);
                Assert.AreEqual(expected.UserId, responseResult.UserId);
                Assert.AreEqual(expected.ProjectId, responseResult.ProjectId);
            };
        }

        [Test]
        public void UpdateUserTest()
        {
            USER item = new USER
            {
                FirstName = "Ryan",
                LastName = "RN",
                UserId = 4,
                EmployeeId = 357844,
                ProjectId = 2
            };

            var response = usrSvc.UpdateUser(item);
            var expectedRes = usrSvc.GetUserbyId(4);
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<USER>), expectedRes);
            USER expected = ((OkNegotiatedContentResult<USER>)expectedRes).Content;

            if (expectedRes != null)
            {
                Assert.AreEqual(expected.FirstName, item.FirstName);
                Assert.AreEqual(expected.LastName, item.LastName);
                Assert.AreEqual(expected.EmployeeId, item.EmployeeId);
                Assert.AreEqual(expected.UserId, item.UserId);
                Assert.AreEqual(expected.ProjectId, item.ProjectId);
            };
        }

        [Test]
        public void AddProjTest()
        {
            var item = new USER
            {
                FirstName = "Nate",
                LastName = "Archie",
                EmployeeId = 108108,
                ProjectId = 2

            };
            var response = usrSvc.AddUser(item);

            var expectedResponse = ((OkNegotiatedContentResult<List<USER>>)usrSvc.GetAllUsers()).Content.Last();

            if (expectedResponse != null)
            {
                Assert.AreEqual(expectedResponse.FirstName, item.FirstName);
                Assert.AreEqual(expectedResponse.LastName, item.LastName);
                Assert.AreEqual(expectedResponse.EmployeeId, item.EmployeeId);
                Assert.AreEqual(expectedResponse.UserId, item.UserId);
                Assert.AreEqual(expectedResponse.ProjectId, item.ProjectId);
            };


        }

        [Test]
        public void DeleteUserTest()
        {
            var response = usrSvc.DeleteUser(10);

            var expectedResponse = usrSvc.GetAllUsers();
            List<USER> responseResult = ((OkNegotiatedContentResult<List<USER>>)expectedResponse).Content;
            Assert.Greater(responseResult.Count, 0);
        }

        [Test]
        public void GetUserByWrongIdTest()
        {
            var response = usrSvc.GetUserbyId(0);
            Assert.AreEqual("System.Web.Http.Results.BadRequestErrorMessageResult", response.GetType().FullName);
        }

        [Test]
        public void UpdateUserByWrongIdTest()
        {
            var item = new USER
            {
                FirstName = "Nate",
                LastName = "Archie",
                EmployeeId = 108108,
                ProjectId = 2,
                UserId = 0

            };
            var response = usrSvc.UpdateUser(item);
            Assert.AreEqual("System.Web.Http.Results.BadRequestErrorMessageResult", response.GetType().FullName);
        }

        [Test]
        public void DeleteUserByWrongIdTest()
        {
            var response = usrSvc.DeleteUser(0);
            Assert.AreEqual("System.Web.Http.Results.BadRequestErrorMessageResult", response.GetType().FullName);
        }
    }
}
