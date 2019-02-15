using System;
using MvcAdoDemo.Models;
using MVCAdoDemo.Models;

namespace Web.Api.IntegrationTests
{
    public static class SeedData
    {
        public static void PopulateTestData(AppIMDBContext dbContext)
        {
            //dbContext.student.Add(new Student("Wayne", "Gretzky", 183, 84, new DateTime(1961,1,26)) { Id = 1, Created = DateTime.UtcNow });           
            dbContext.stud.Add(new Student(){
                    Name ="AAAAA",
                    Gender="M",
                    Department ="D",
                    City = "D"
                });
            dbContext.SaveChanges();
        }
    }
}