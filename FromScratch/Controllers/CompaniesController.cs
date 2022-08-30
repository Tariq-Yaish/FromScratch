using FromScratch.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FromScratch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private static List<Company> companies = new List<Company>()
        {
            new Company
            {
                Company_ID = 1 ,
                Company_Name = "IConnect" ,
                Location = "Birah - Ramallah - Palestine"
            },

            new Company
            {
                Company_ID = 2 ,
                Company_Name = "BioLine" ,
                Location = "AlAhliya - Ramallah - Palestine"
            }
        };

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Company>>> Get()
        {
            return Ok(companies);
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        { 
            var company = companies.Find(x => x.Company_ID == id);

            if (company == null)
                return BadRequest("No such company");

            return Ok(company);
        }

        [HttpPost("AddACompany")]
        public async Task<ActionResult<List<Company>>> AddCompany(Company newCompany)
        {
            if (newCompany == null)
                return BadRequest("The object transfered is null");

            companies.Add(newCompany);
            return Ok(companies);
        }

        [HttpPut("UpdateACompany")]
        public async Task<ActionResult<List<Company>>> UpdateCompany(Company newCompany)
        {
            var company = companies.Find(x => x.Company_ID == newCompany.Company_ID);

            if (company == null)
                return BadRequest("No such company");

            company.Company_ID = newCompany.Company_ID;
            company.Company_Name = newCompany.Company_Name;
            company.Location = newCompany.Location;

            return Ok(companies);
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult<List<Company>>> Delete(int id)
        {
            var company = companies.Find(x => x.Company_ID == id);

            if (company == null)
                return BadRequest("No such company");

            companies.Remove(company);
            return Ok(companies);
        }
    }
}
