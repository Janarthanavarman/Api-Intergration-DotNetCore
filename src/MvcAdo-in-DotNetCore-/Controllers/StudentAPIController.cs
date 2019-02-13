using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCAdoDemo.Models;

namespace MVCAdoDemo.Controllers
{
    [Route("api/[controller]/[action]")]//
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        StudentDataAccessLayer objStudent = new StudentDataAccessLayer();

        [HttpGet]
        public IEnumerable<Object> DashBoard()
        {
            try
            {
                List<Student> lstStudent = new List<Student>();
                lstStudent = objStudent.GetAllstudents().ToList();

                return lstStudent;
            }
            catch
            {
                return null;
            }
        }


        [HttpPost]
        public IActionResult create([Bind] Student Student)
        {
            try
            {
                objStudent.AddEmployee(Student);
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        
[HttpGet]
        public IActionResult Edit(int? id)
        {
            return Ok(objStudent.GetEmployee(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] Student Student)
        {
            if (ModelState.IsValid)
            {
                objStudent.UpdateEmployee(Student);
                return NoContent();
            }
            else
            {
                objStudent.UpdateEmployee(Student);
                return NoContent();
            }

        }

[HttpDelete]
        public IActionResult Delete(int? id)
        {
            objStudent.DeleteEmployee(id);
            return NoContent();
        }


    }
}