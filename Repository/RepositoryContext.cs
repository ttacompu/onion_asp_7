using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuraton;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
             .ApplyConfiguration(new CompanyConfiguration())
            .ApplyConfiguration(new EmployeeConfiguration());
            
        }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<Employee>? Employees { get; set; }

    }
}