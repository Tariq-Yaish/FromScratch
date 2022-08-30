using FromScratch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FromScratch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Employee_ID = 1,
                Employee_Name = "Zain",
                Employee_Age = 25,
                Comapny_Id = 1
            },

            new Employee()
            {
                Employee_ID = 2,
                Employee_Name = "Nobody",
                Employee_Age = 22,
                Comapny_Id = 2
            }
        };

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(employees);
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = employees.Find(x => x.Employee_ID == id);

            if (employee == null)
                return BadRequest("No such employee");

            return Ok(employee);
        }

        [HttpPost("AddAnEmployee")]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee newEmployee)
        {
            if (newEmployee == null)
                return BadRequest("The object transfered is null");

            employees.Add(newEmployee);
            return Ok(employees);
        }

        [HttpPut("UpdateAnEmployee")]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee newEmployee)
        {
            var employee = employees.Find(x => x.Employee_ID == newEmployee.Employee_ID);

            if (employee == null)
                return BadRequest("No such employee");

            employee.Employee_ID = newEmployee.Employee_ID;
            employee.Employee_Name = newEmployee.Employee_Name;
            employee.Employee_Age = newEmployee.Employee_Age;
            employee.Comapny_Id = newEmployee.Comapny_Id;

            return Ok(employees);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult<List<Employee>>> Delete(int id)
        {
            var employee = employees.Find(x => x.Employee_ID == id);

            if (employee == null)
                return BadRequest("No such employee");

            employees.Remove(employee);
            return Ok(employees);
        }
    }
}
