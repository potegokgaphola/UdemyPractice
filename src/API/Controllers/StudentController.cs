using Microsoft.AspNetCore.Mvc;
using System.Linq;
using API.Models;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion( "1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(StudentStatic.GetAllStudent());
        }

        [HttpGet("{email}")]
        public IActionResult GetA(string email)
        {
            return Ok(StudentStatic.GetAStudent(email));
        }

        [HttpPost]
        public IActionResult Insert(Student student)
        {
            return Ok(StudentStatic.InsertStudent(student));
        }

        [HttpPut("{email}")]
        public IActionResult Update(string email, Student student)
        {
            return Ok(StudentStatic.UpdateStudent(email, student));
        }

        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            return Ok(StudentStatic.DeleteStudent(email));
        }
    }

    public static class StudentStatic
    {
        private static List<Student> allStudents { get; set; } = new List<Student>();

        public static Student InsertStudent(Student student)
        {
            allStudents.Add(student);
            return student;
        }

        public static List<Student> GetAllStudent()
        {
            return allStudents;
        }

        public static Student GetAStudent(string email)
        {
            return allStudents.FirstOrDefault(student => student.Email == email);
        }

        public static Student  UpdateStudent(string email, Student student)
        {
            Student result = new Student();
            foreach (var item in allStudents)
            {
                if(email == item.Email)
                {
                    item.Name = student.Name;
                    result = item;
                }
            }
            return result;
        }

        public static Student DeleteStudent(string email)
        {
            var _student = allStudents.FirstOrDefault(student => student.Email == email);
            allStudents = allStudents.Where(student => student.Email != _student.Email).ToList();
            return _student;
        }
    }
}