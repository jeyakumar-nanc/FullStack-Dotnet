using ProjManager.BusinessService;
using ProjManager.Data;
using System.Web.Http;

namespace ProjManagerSvc.Controllers
{
    [RoutePrefix("Project")]
    public class ProjectController : ApiController
    {
        ProjectService projService = new ProjectService();

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllProjects()
        {
            try
            {
                var projList = projService.GetAllProjects();
                return Ok(projList);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Route("Get/{id}")]
        [HttpGet]
        public IHttpActionResult GetProjbyId(int id)
        {
            try
            {
                var proj = projService.GetProjbyId(id);
                return Ok(proj);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("Add")]
        [HttpPost]
        public IHttpActionResult AddProj(PROJECT proj)
        {
            try
            {
                projService.AddProj(proj);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update")]
        [HttpPut]
        public IHttpActionResult UpdateProj(PROJECT proj)
        {
            try
            {
                projService.UpdateProj(proj);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Remove/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteProj(int id)
        {
            try
            {
                var updatedList = projService.DeleteProj(id);
                return Ok(updatedList);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}