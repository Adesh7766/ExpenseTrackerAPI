using ExpenseTrackerAPI.BAL.Interface;
using ExpenseTrackerAPI.Entity.DTO;
using ExpenseTrackerAPI.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("GetAllUsers")]
        public ActionResult GetUsers([FromQuery] string name = "")
        {
            var response = _service.GetList(name);

            if (response.SuccessStatus)
            {
                return Ok(new
                {
                    Success = true,
                    Users = response.Data
                });
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("RegisterUser")]
        public ActionResult SaveUser([FromBody] UserDTO user)
        {
            if(user == null)
            {
                return BadRequest("Please enter user data.");
            }
            else
            {
                var response = _service.Save(user);

                if(response.SuccessStatus == true)
                {
                    return Ok(response.Message);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
        }

        [HttpGet("DeleteUser")]
        public ActionResult DeleteUser(int id)
        {
            var response = _service.Delete(id);

            if (response.SuccessStatus)
            {
                return Ok(response.Message);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
