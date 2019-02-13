using System;    
using System.Collections.Generic;    
using System.Data;    
using System.Data.SqlClient;    
using System.Linq;    
using System.Threading.Tasks;    
    
namespace MVCAdoDemo.Models    
{    
    public class StudentDataAccessLayer    
    {    
            // "DefaultConnection": "Server=tcp:xxUAT.domain.com,64609;Initial Catalog=IdentityDB;MultipleActiveResultSets=true;User ID=xx;Password=xx"

        string connectionString = "Server=10.100.8.148;Initial Catalog=training;;MultipleActiveResultSets=true;User ID=training;password=training";    
    
        
        public IEnumerable<Student> GetAllstudents()    
        {    
            List<Student> lststudent= new List<Student>();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {    
                    Student Student = new Student();    
    
                    Student.ID = Convert.ToInt32(rdr["EmployeeId"]);    
                    Student.Name = rdr["Name"].ToString();    
                    Student.Gender = rdr["Gender"].ToString();    
                    Student.Department = rdr["Department"].ToString();    
                    Student.City = rdr["City"].ToString();    
    
                    lststudent.Add(Student);    
                }    
                con.Close();    
            }    
            return lststudent;    
        }


 public Student GetEmployee(int? id)    
        {    
            Student student= new Student();    
    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spGetEmployees", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Parameters.AddWithValue("@ID", id); 
                con.Open();    
                SqlDataReader rdr = cmd.ExecuteReader();    
    
                while (rdr.Read())    
                {   
                    student.ID = Convert.ToInt32(rdr["EmployeeId"]);    
                    student.Name = rdr["Name"].ToString();    
                    student.Gender = rdr["Gender"].ToString();    
                    student.Department = rdr["Department"].ToString();    
                    student.City = rdr["City"].ToString(); 
                }    
                con.Close();    
            }    
            return student;    
        }

      
      
        public void AddEmployee(Student Student)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@Name", Student.Name);    
                cmd.Parameters.AddWithValue("@Gender", Student.Gender);    
                cmd.Parameters.AddWithValue("@Department", Student.Department);    
                cmd.Parameters.AddWithValue("@City", Student.City);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }

          public void UpdateEmployee(Student Student)    
        {    
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spEditEmployee", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
    
                cmd.Parameters.AddWithValue("@ID", Student.ID);
                cmd.Parameters.AddWithValue("@Name", Student.Name);    
                cmd.Parameters.AddWithValue("@Gender", Student.Gender);    
                cmd.Parameters.AddWithValue("@Department", Student.Department);    
                cmd.Parameters.AddWithValue("@City", Student.City);    
    
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }    
        }


        internal void DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))    
            {    
                SqlCommand cmd = new SqlCommand("spDeleteEmployees", con);    
                cmd.CommandType = CommandType.StoredProcedure;   
                cmd.Parameters.AddWithValue("@ID", id);                   
                con.Open();    
                cmd.ExecuteNonQuery();    
                con.Close();    
            }  
        }
    }    
}