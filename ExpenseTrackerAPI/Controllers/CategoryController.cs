using ExpenseTrackerAPI.BAL.Interface;
using ExpenseTrackerAPI.Entity.DTO;
using ExpenseTrackerAPI.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetAllCategory")]
        public ActionResult GetCategory([FromQuery] string name = "", string code = "")
        {
            var response = _service.GetList(name, code);

            if (response.SuccessStatus)
            {
                return Ok(new
                {
                    Success = true,
                    Category = response.Data
                });
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost("RegisterCategory")]
        public ActionResult SaveCategory([FromBody] CategoryDTO category)
        {
            if (category == null)
            {
                return BadRequest("Please enter category data.");
            }
            else
            {
                var response = _service.Save(category);

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

        [HttpGet("DeleteCategory")]
        public ActionResult DeleteCategory(int id)
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

        [HttpGet("GetCategoryById")]
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
