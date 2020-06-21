using ProjManager.BusinessService;
using ProjManager.Data;
using System.Web.Http;

namespace ProjManagerSvc.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        UserService userService = new UserService();

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                var userList = userService.GetUsers();
                return Ok(userList);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Get/{id}")]
        [HttpGet]
        public IHttpActionResult GetUserbyId(int id)
        {
            try
            {
                var user = userService.GetUserbyId(id);
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Add")]        
        [HttpPost]
        public IHttpActionResult AddUser([FromBody] USER user)
        {
            try
            {
                userService.AddUser(user);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Update")]
        [HttpPut]
        public IHttpActionResult UpdateUser([FromBody] USER user)
        {
            try
            {
                userService.UpdateUser(user);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Remove/{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            try
            {
                var updatedList = userService.DeleteUser(id);
                return Ok(updatedList);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
