using System;    
using System.Collections.Generic;    
using System.Data;    
using System.Data.SqlClient;    
using System.Linq;    
using System.Threading.Tasks;
using MvcAdoDemo.Models;

namespace MVCAdoDemo.Models    
{    
    public class StudentIMDataAccessLayer    :IStudentIMDataAccessLayer
    {    
            // "DefaultConnection": "Server=tcp:xxUAT.domain.com,64609;Initial Catalog=IdentityDB;MultipleActiveResultSets=true;User ID=xx;Password=xx"
       AppIMDBContext context;
       public  StudentIMDataAccessLayer(AppIMDBContext context)
        {
            this.context=context;
        }
        public IEnumerable<Student> GetAllstudents()    
        {               
            return context.stud.ToList();    
        }


        public Student GetEmployee(int id)    
        {    
            return context.stud.ToList().Where(x => x.ID ==id).FirstOrDefault(); 
        }

      
      
        public void AddEmployee(Student Student)    
        {    
           context.Add(Student);
           context.SaveChanges();
        }

          public bool UpdateEmployee(int id,Student s)    
        {    
          try{

              var std = context.stud.Where(x=>x.ID ==id).FirstOrDefault();
              if(std!=null){
                  std.Name =s.Name;
               context.stud.Update(std);
               context.SaveChanges();
               return true;
              }
            return false;
          }catch(Exception ex){
              Console.Write(ex.Message);

                return false;
          }                   
          
        }


        public bool DeleteEmployee(int id)
        {            
            try
           {        
                var std = context.stud.Where(x=>x.ID ==id).FirstOrDefault();
              if(std!=null){       
               context.stud.Remove(std);
               context.SaveChanges();
               return true;
              }
              return false;
            }catch(Exception ex){
              Console.Write(ex.Message);

                return false;
          }             
          
        }

        

        
    }    
}