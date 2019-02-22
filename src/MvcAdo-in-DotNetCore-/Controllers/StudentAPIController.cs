using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using MVCAdoDemo.Models;


namespace MVCAdoDemo.Controllers
{
    [Route("api/[controller]")]//
    [ApiController]
    [EnableCors("ngCrosPolicy")]
    public class StudentAPIController : ControllerBase
    {
         IStudentIMDataAccessLayer objStudent;
       public  StudentAPIController(IStudentIMDataAccessLayer objStudent){
            this.objStudent =objStudent;
        }

        [HttpGet]
        public IActionResult DashBoard()
        {
            try
            {
                List<Student> lstStudent = new List<Student>();
                lstStudent = objStudent.GetAllstudents().ToList();
                return Ok(lstStudent);
            }
            catch
            {
                return NotFound();
            }
        }


        [HttpPut]
        public IActionResult create([FromBody] Student Student)
        {
            try
            {
                if(objStudent.AddEmployee(Student)){
                    return StatusCode(201);
                }
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        
      [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            
            try{
                var re =objStudent.GetEmployee(id);
                if(re!=null)
                return Ok(re);
                return NotFound();
            }catch{                
                return NotFound();
            }
        }

        [HttpPost("{id}")]
       
        public IActionResult Update(int id,[FromBody] Student Student)
        {
         try{   if (ModelState.IsValid)
            {
               if( objStudent.UpdateEmployee(id,Student)){
                   return Accepted();
               }
                return NotFound();
            }
            else
            {
                if( objStudent.UpdateEmployee(id,Student)){
                   return Accepted();
               }
                return NotFound();
            }
         }catch{
             return BadRequest();
         }

        }

[HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           if(objStudent.DeleteEmployee(id)){
                   return Accepted();
               }
                return NotFound();                           
        }


    }
}