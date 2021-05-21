using DapperOrmDemo.Model;
using DapperOrmDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperOrmDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository employeeRepository;
        public EmployeeController() {
            employeeRepository = new EmployeeRepository();
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            var strResult = "";
            try
            {
                strResult = JsonConvert.SerializeObject(employeeRepository.GetAllEmployee()); 
                return new ContentResult() { StatusCode = StatusCodes.Status200OK, ContentType = "application/json", Content = strResult };
            }
            catch (Exception ex)
            {

                return new ContentResult() { StatusCode = StatusCodes.Status500InternalServerError, ContentType = "text/plain", Content = ex.Message };
            }
           
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {
            var strResult = "";
            try
            { 
                strResult = JsonConvert.SerializeObject(employeeRepository.GetById(id));
                return new ContentResult() { StatusCode = StatusCodes.Status200OK, ContentType = "application/json", Content = strResult };
            }
            catch (Exception ex)
            {

                return new ContentResult() { StatusCode = StatusCodes.Status500InternalServerError, ContentType = "text/plain", Content = ex.Message };
            }
           
        }
        [HttpPost]
        public IActionResult Post([FromBody] Employee Emp) 
        {
            try
            {
                if (ModelState.IsValid)
                    employeeRepository.Add(Emp);
                    return new ContentResult() { StatusCode = StatusCodes.Status200OK, ContentType = "application/json", Content = "Record saved successfully"};
            }
            catch (Exception ex)
            {

                return new ContentResult() { StatusCode = StatusCodes.Status500InternalServerError, ContentType = "text/plain", Content = ex.Message };
            }
            
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Employee Emp)
        {
            try
            {
                Emp.EmployeeId = id;
                if (ModelState.IsValid)
                    employeeRepository.Update(Emp);
                    return new ContentResult() { StatusCode = StatusCodes.Status200OK, ContentType = "application/json", Content = "Record updated successfully" };
            }
            catch (Exception ex)
            {

                return new ContentResult() { StatusCode = StatusCodes.Status500InternalServerError, ContentType = "text/plain", Content = ex.Message };
            }
           
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                employeeRepository.Delete(id);
                return new ContentResult() { StatusCode = StatusCodes.Status200OK, ContentType = "application/json", Content = "Record deleted successfully" };
            }
            catch (Exception ex)
            {

                return new ContentResult() { StatusCode = StatusCodes.Status500InternalServerError, ContentType = "text/plain", Content = ex.Message };
            }
               
        }



    }
}
