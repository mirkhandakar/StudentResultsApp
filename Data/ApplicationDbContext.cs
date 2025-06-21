using Microsoft.EntityFrameworkCore;
using StudentResultsApp.Models;

namespace StudentResultsApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentResult> StudentResults { get; set; }
    }
}
