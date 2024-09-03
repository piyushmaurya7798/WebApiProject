using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
        
        }
        public DbSet<Emp> Emps { get; set; }


    }
}
