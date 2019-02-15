

using System.Collections.Generic;

namespace MVCAdoDemo.Models    
{    
    public interface IStudentIMDataAccessLayer    
    {  
          IEnumerable<Student> GetAllstudents() ;
           Student GetEmployee(int id) ;       
          void AddEmployee(Student Student);        
          bool UpdateEmployee(int id,Student s) ;  
          bool DeleteEmployee(int id);
    }    
}