using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCAdoDemo.Models;

namespace MVCAdoDemo.Controllers
{
    public class StudentController : Controller
    {
        //StudentDataAccessLayer objStudent = new StudentDataAccessLayer();
        IStudentIMDataAccessLayer objStudent;
        public StudentController(IStudentIMDataAccessLayer objStudent){
            this.objStudent =objStudent;
        }
        

        public IActionResult Index()
        {
            List<Student> lstStudent = new List<Student>();
            lstStudent = objStudent.GetAllstudents().ToList();

            return View(lstStudent);
        }

        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create([Bind] Student Student)
        {
            if (ModelState.IsValid)
            {
                objStudent.AddEmployee(Student);
                return RedirectToAction("Index");
            }
            return View(Student);
        }


        public IActionResult Edit(int id)
        {
            return View(objStudent.GetEmployee(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,[Bind] Student Student)
        {
            if (ModelState.IsValid)
            {
                objStudent.UpdateEmployee(id,Student);
                return RedirectToAction("Index");
            }
            return View(Student);
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            objStudent.DeleteEmployee(id);
            return RedirectToAction("Index");
        }


    }
}