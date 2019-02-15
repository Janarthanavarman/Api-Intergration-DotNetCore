
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCAdoDemo.Models;

namespace MvcAdoDemo.Models
{
    public class AppIMDBContext : DbContext
    {

        public AppIMDBContext(DbContextOptions<AppIMDBContext> DBIM) : base(DBIM)
        {
            if(stud.ToListAsync().Result.Count==0)
            {
            stud.Add(
                new Student(){
                    Name ="AAAAA",
                    Gender="M",
                    Department ="A",
                    City = "A"
                });

              stud.Add(
                 new Student(){
                    Name ="BBBBB",
                    Gender="F",
                    Department ="B",
                    City = "B"
                 });  
            }        

            SaveChanges();
        }
        public DbSet<Student> stud{get;set;}
    }
}