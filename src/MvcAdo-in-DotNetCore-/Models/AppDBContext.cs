
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCAdoDemo.Models;

namespace MvcAdoDemo.Models
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions DBIM) : base(DBIM)
        {
           

         //dotnet ef dbcontext scaffold "Server=10.100.8.148;Initial Catalog=training;;MultipleActiveResultSets=true;User ID=training;password=training;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models/DB -t Vendor --context-dir Context -c BlogContext
        }
       // public DbSet<Vendor> stud{get;set;}
    }
}