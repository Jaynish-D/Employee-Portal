using EmployeePortal.Models;
using EmployeePortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(EmployeeRepository employeeRepository) : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository = employeeRepository;

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var result = await _employeeRepository.GetEmployeesAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                await _employeeRepository.SaveEmployee(employee);
                return Ok(employee);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
