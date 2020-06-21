using ProjManager.BusinessService;
using ProjManager.Data;
using System.Web.Http;

namespace ProjManagerSvc.Controllers
{
    [RoutePrefix("Task")]
    public class TaskController : ApiController
    {
        TaskService taskService = new TaskService();

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllTasks()
        {
            try
            {
                var projList = taskService.GetAllTasks();
                return Ok(projList);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Get/{id}")]
        [HttpGet]
        public IHttpActionResult GetTaskbyId(int id)
        {
            try
            {
                var proj = taskService.GetTaskbyId(id);
                return Ok(proj);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult AddTask(TASK task)
        {
            try
            {
                taskService.AddTask(task);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update")]
        [HttpPut]
        public IHttpActionResult UpdateTask(TASK task)
        {
            try
            {
                taskService.UpdateTask(task);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Remove/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteTask(int id)
        {
            try
            {

                var updatedList = taskService.DeleteTask(id);
                return Ok(updatedList);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("EndTask")]
        [HttpPut]
        public IHttpActionResult EndTask(TASK task)
        {
            try
            {
                taskService.EndTask(task);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("GetParentTask")]
        [HttpGet]
        public IHttpActionResult GetAllParentTasks()
        {
            try
            {
                var ptList = taskService.GetAllParentTasks();
                return Ok(ptList);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}