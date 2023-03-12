using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API.Models;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion( "1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(DeparmentStatic.GetAllDepartment());
        }

        [HttpGet("{code}")]
        public IActionResult GetA(string code)
        {
            return Ok(DeparmentStatic.GetADepartment(code));
        }

        [HttpPost]
        public IActionResult Insert(Department department)
        {
            return Ok(DeparmentStatic.InsertDepartment(department
            ));
        }

        [HttpPut("{code}")]
        public IActionResult Update(string code, Department department)
        {
            return Ok(DeparmentStatic.UpdateDepartment(code, department));
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(string code)
        {
            return Ok(DeparmentStatic.DeleteDepartment(code));
        }
    }

    public static class DeparmentStatic
    {
        private static List<Department> allDepartments { get; set; } = new List<Department>();

        public static Department InsertDepartment(Department department)
        {
            allDepartments.Add(department);
            return department;
        }

        public static List<Department> GetAllDepartment()
        {
            return allDepartments;
        }

        public static Department GetADepartment(string code)
        {
            return allDepartments.FirstOrDefault(department => department.Code == code);
        }

        public static Department  UpdateDepartment(string code, Department department)
        {
            Department result = new Department();
            foreach (var item in allDepartments)
            {
                if(code == item.Code)
                {
                    item.Name = department.Name;
                    result = item;
                }
            }
            return result;
        }

        public static Department DeleteDepartment(string code)
        {
            var _department = allDepartments.FirstOrDefault(department => department.Code == code);
            allDepartments = allDepartments.Where(department => department.Code != _department.Code).ToList();
            return _department;
        }
    }
}