using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.AppCode.Interface;
using WebAPI.AppCode.Services;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _empservice;
        public EmployeeController(IEmployeeService empservice)
        {
            _empservice = empservice;
        }
        [HttpGet("GetDepartment")]
        public async Task<IActionResult> GetDepartment()
        {
            var res = await _empservice.GetDepartment();
            return Ok(res);
        }
        [HttpPost("AddEployee")]
        public async Task<IActionResult> AddEployee(Employee req)
        {
            var res = await _empservice.AddAsync(req);
            return Ok(res);
        }
        [HttpPost("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            var res = await _empservice.GetEmployee();
            return Ok(new
            {
                Statuscode = 1,
                Msg = "Success",
                data = res
            });
        }
        [HttpPost("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            var res = await _empservice.GetEmployeeById(Id);
            return Ok(new
            {
                Statuscode = 1,
                Msg = "Success",
                data = res
            });
        }
        [HttpDelete("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            var res = await _empservice.Delete(Id);
            return Ok(res);
        }
    }
}
