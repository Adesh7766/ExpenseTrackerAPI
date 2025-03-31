using ExpenseTrackerAPI.BAL.Interface;
using ExpenseTrackerAPI.Entity.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;

        public StatusController(IStatusService service)
        {
            _service = service;
        }

        [HttpGet("GetAllStatus")]
        public ActionResult GetStatus([FromQuery] string name = "", string code = "")
        {
            var response = _service.GetList(name, code);

            if (response.SuccessStatus)
            {
                return Ok(new
                {
                    Success = true,
                    Status = response.Data
                });
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("RegisterStatus")]
        public ActionResult SaveStatus([FromBody] StatusDTO status)
        {
            if (status == null)
            {
                return BadRequest("Please enter status data.");
            }
            else
            {
                var response = _service.Save(status);

                if (response.SuccessStatus == true)
                {
                    return Ok(response.Message);
                }
                else
                {
                    return BadRequest(response.Message);
                }
            }
        }

        [HttpGet("DeleteStatus")]
        public ActionResult DeleteStatus(int id)
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

        [HttpGet("GetStatusById")]
        public ActionResult GetById(int id)
        {
            var response = _service.GetById(id);

            if (response.SuccessStatus)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
