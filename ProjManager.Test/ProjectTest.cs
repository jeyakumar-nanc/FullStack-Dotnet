using NUnit.Framework;
using ProjManager.Data;
using ProjManagerSvc.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace ProjManager.Test
{
    [TestFixture]
    public class ProjectTest
    {
        private readonly ProjectController projSvc;
        public ProjectTest()
        {
            projSvc = new ProjectController();
        }

        [Test]
        public void GetAllProjectTest()
        {

            var response = projSvc.GetAllProjects();        
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<List<PROJECT>>), response);
            List<PROJECT> responseResult = ((OkNegotiatedContentResult<List<PROJECT>>)response).Content;                     
            Assert.Greater(responseResult.Count, 0);
        }

        [Test]
        public void GetProjByIdTest()
        {
            PROJECT expected = new PROJECT
            {
                ProjectId = 1,
                ProjectName = "FSE-Developement",
                Priority = 1,
                StartDate = new System.DateTime(2020, 05, 17),
                EndDate = new System.DateTime(2020, 12, 31)
            };
            var response = projSvc.GetProjbyId(1);            
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<PROJECT>), response);
            PROJECT responseResult = (PROJECT)((OkNegotiatedContentResult<PROJECT>)response).Content;
            if (responseResult != null)
            {                
                Assert.AreEqual(expected.StartDate, responseResult.StartDate);
                Assert.AreEqual(expected.EndDate, responseResult.EndDate);
                Assert.AreEqual(expected.Priority, responseResult.Priority);
                Assert.AreEqual(expected.ProjectId, responseResult.ProjectId);
                Assert.AreEqual(expected.ProjectName, responseResult.ProjectName);
            };
        }

        [Test]
        public void UpdateProjTest()
        {
            var item = new PROJECT
            {
                ProjectId = 2,
                ProjectName = "FSE-Testing",
                Priority = 1,
                StartDate = new System.DateTime(2020, 06, 16),
                EndDate = new System.DateTime(2020, 12, 31)

            };
            var response = projSvc.UpdateProj(item);            
            var expectedRes = projSvc.GetProjbyId(2);
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<PROJECT>), expectedRes);
            PROJECT expected = (PROJECT)((OkNegotiatedContentResult<PROJECT>)expectedRes).Content;

            if (expectedRes != null)
            {                
                Assert.AreEqual(expected.StartDate, item.StartDate);
                Assert.AreEqual(expected.EndDate, item.EndDate);
                Assert.AreEqual(expected.Priority, item.Priority);
                Assert.AreEqual(expected.ProjectId, item.ProjectId);
                Assert.AreEqual(expected.ProjectName, item.ProjectName);
            };            
        }

        [Test]
        public void AddProjTest()
        {
            var item = new PROJECT
            {                
                ProjectName = "Data-CenterMigrationSupport-2",
                Priority = 5,
                StartDate = new System.DateTime(2020, 06, 16),
                EndDate = new System.DateTime(2020, 12, 31)

            };
            var response = projSvc.AddProj(item);

            var expectedResponse = ((OkNegotiatedContentResult<List<PROJECT>>)projSvc.GetAllProjects()).Content.Last();

            if (expectedResponse != null)
            {
                Assert.AreEqual(expectedResponse.StartDate, item.StartDate);
                Assert.AreEqual(expectedResponse.EndDate, item.EndDate);
                Assert.AreEqual(expectedResponse.Priority, item.Priority);
                Assert.AreEqual(expectedResponse.ProjectId, item.ProjectId);
                Assert.AreEqual(expectedResponse.ProjectName, item.ProjectName);
            };
        }


        [Test]
        public void GetProjByWrongIdTest()
        {
            var response = projSvc.GetProjbyId(0);            
            Assert.AreEqual("System.Web.Http.Results.BadRequestErrorMessageResult", response.GetType().FullName);            
        }

        [Test]
        public void UpdateProjByWrongIdTest()
        {
            var item = new PROJECT
            {
                ProjectId = 0,
                ProjectName = "FSE-Testing",
                Priority = 1,
                StartDate = new System.DateTime(2020, 06, 16),
                EndDate = new System.DateTime(2020, 12, 31)

            };
            var response = projSvc.UpdateProj(item);
            Assert.AreEqual("System.Web.Http.Results.BadRequestErrorMessageResult", response.GetType().FullName);
        }
       
    }
}

