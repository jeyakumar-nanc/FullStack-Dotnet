using NUnit.Framework;
using ProjManager.Data;
using ProjManagerSvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace ProjManager.Test
{
    [TestFixture]
    class TaskTest
    {
        private readonly TaskController taskSvc;
        public TaskTest()
        {
            taskSvc = new TaskController();
        }

        [Test]
        public void GetAllTaskTest()
        {
            var response = taskSvc.GetAllTasks();
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<List<TaskData>>), response);
            List<TaskData> responseResult = ((OkNegotiatedContentResult<List<TaskData>>)response).Content;
            Assert.Greater(responseResult.Count, 0);
        }

        [Test]
        public void GetAllParentTaskTest()
        {
            var response = taskSvc.GetAllParentTasks();
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<List<PARENT_TASK>>), response);
            List<PARENT_TASK> responseResult = ((OkNegotiatedContentResult<List<PARENT_TASK>>)response).Content;
            Assert.Greater(responseResult.Count, 0);
        }

        [Test]
        public void GetTaskByIdTest()
        {
            var expected = new TaskData
            {
                TaskName = "FSE-Env Setup",
                ProjectId = 1,
                ProjectName = "FSE-Developement",
                StartDate = new DateTime(2020,05,17),
                EndDate = new DateTime(2020, 05, 22),
                ParentTask = "Env Setup",
                TaskId = 1,
                Status = "In Progress",
                Priority = 1,
                User = "Nancy" + " " + "DJ"
            };
            var response = taskSvc.GetTaskbyId(1);
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<TaskData>), response);
            TaskData responseResult = ((OkNegotiatedContentResult<TaskData>)response).Content;
            if (responseResult != null)
            {
                Assert.AreEqual(expected.TaskName, responseResult.TaskName);
                Assert.AreEqual(expected.ProjectId, responseResult.ProjectId);
                Assert.AreEqual(expected.ProjectName, responseResult.ProjectName);
                Assert.AreEqual(expected.StartDate, responseResult.StartDate);
                Assert.AreEqual(expected.EndDate, responseResult.EndDate);
                Assert.AreEqual(expected.ParentTask, responseResult.ParentTask);
                Assert.AreEqual(expected.TaskId, responseResult.TaskId);
                Assert.AreEqual(expected.Status, responseResult.Status);
                Assert.AreEqual(expected.Priority, responseResult.Priority);
                Assert.AreEqual(expected.User, responseResult.User);
            };
        }

        [Test]
        public void UpdateTaskTest()
        {
            var item = new TASK
            {
                TaskName = "FSE-Env Setup",
                ProjectId = 1,                
                StartDate = new DateTime(2020, 05, 17),
                EndDate = new DateTime(2020, 05, 22),                
                TaskId = 1,
                Status = "In Progress",
                Priority = 1,
                ParentId = 1,
                UserId = 9                
            };

            var expected = new TaskData
            {
                TaskName = "FSE-Env Setup",
                ProjectId = 1,
                ProjectName = "FSE-Developement",
                StartDate = new DateTime(2020, 05, 17),
                EndDate = new DateTime(2020, 05, 22),
                ParentTask = "Env Setup",
                TaskId = 1,
                Status = "In Progress",
                Priority = 1,                               
                User = "Nancy" + " " + "DJ"
            };

            var response = taskSvc.UpdateTask(item);
            var expectedRes = taskSvc.GetTaskbyId(1);
            Assert.IsInstanceOf(typeof(OkNegotiatedContentResult<TaskData>), expectedRes);
            TaskData actual = ((OkNegotiatedContentResult<TaskData>)expectedRes).Content;

            if (expectedRes != null)
            {
                Assert.AreEqual(expected.TaskName, actual.TaskName);
                Assert.AreEqual(expected.ProjectId, actual.ProjectId);
                Assert.AreEqual(expected.ProjectName, actual.ProjectName);
                Assert.AreEqual(expected.StartDate, actual.StartDate);
                Assert.AreEqual(expected.EndDate, actual.EndDate);
                Assert.AreEqual(expected.ParentTask, actual.ParentTask);
                Assert.AreEqual(expected.TaskId, actual.TaskId);
                Assert.AreEqual(expected.Status, actual.Status);
                Assert.AreEqual(expected.Priority, actual.Priority);
                Assert.AreEqual(expected.User, actual.User);
            };
        }

        [Test]
        public void AddTaskTest()
        {
            var item = new TASK
            {
                TaskName = "DR-Env Setup",
                ProjectId = 1,                
                StartDate = new DateTime(2020, 08, 17),
                EndDate = new DateTime(2020, 08, 22),                
                TaskId = 1,
                Status = "Not Started",
                Priority = 1,
                ParentId = 1,
                UserId = 9
            };
            var response = taskSvc.AddTask(item);

            var expectedResponse = ((OkNegotiatedContentResult<List<TaskData>>)taskSvc.GetAllTasks()).Content.Last();

            if (expectedResponse != null)
            {
                Assert.AreEqual(expectedResponse.StartDate, item.StartDate);
                Assert.AreEqual(expectedResponse.EndDate, item.EndDate);
                Assert.AreEqual(expectedResponse.Priority, item.Priority);
                Assert.AreEqual(expectedResponse.ProjectId, item.ProjectId);
                //Assert.AreEqual(expectedResponse.ProjectName, item.ProjectName);
            };
        }


        [Test]
        public void GetTaskByWrongIdTest()
        {
            var response = taskSvc.GetTaskbyId(0);
            Assert.AreEqual("System.Web.Http.Results.BadRequestErrorMessageResult", response.GetType().FullName);
        }

        [Test]
        public void UpdateTaskByWrongIdTest()
        {
            var item = new TASK
            {
                TaskName = "FSE-Env Setup",
                ProjectId = 1,
                StartDate = new DateTime(2020, 05, 17),
                EndDate = new DateTime(2020, 05, 22),
                TaskId = 0,
                Status = "In Progress",
                Priority = 1,
                ParentId = 1,
                UserId = 9
            };
            var response = taskSvc.UpdateTask(item);
            Assert.AreEqual("System.Web.Http.Results.BadRequestErrorMessageResult", response.GetType().FullName);
        }       
    }
}
