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
         IStudentIMDataAccessLayer objStudent;
       public  StudentAPIController(IStudentIMDataAccessLayer objStudent){
            this.objStudent =objStudent;
        }

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
        public IActionResult Edit(int id)
        {
            return Ok(objStudent.GetEmployee(id));
        }

        [HttpPost]
       
        public IActionResult Update(int id,[FromBody] Student Student)
        {
         try{   if (ModelState.IsValid)
            {
               if( objStudent.UpdateEmployee(id,Student)){
                   return Accepted();
               }
                return NoContent();
            }
            else
            {
                if( objStudent.UpdateEmployee(id,Student)){
                   return Accepted();
               }
                return NoContent();
            }
         }catch{
             return BadRequest();
         }

        }

[HttpDelete]
        public IActionResult Delete(int id)
        {
           if(  objStudent.DeleteEmployee(id)){
                   return Accepted();
               }
                return NoContent();                           
        }


    }
}