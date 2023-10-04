using System;
using Microsoft.EntityFrameworkCore;
namespace EXAMP.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}