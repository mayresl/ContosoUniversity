using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        /*
             DbSet<Enrollment> and DbSet<Course> can be omitted. 
             EF Core includes them implicitly because the Student entity references the Enrollment entity, 
             and the Enrollment entity references the Course entity.
        */
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        /*
             Since EF Core creates tables that have names the same as the DbSet property names and property names 
             for collections are typically plural, you can use the following code to specify singular table names
             (developers disagree about whether table names should be plural)
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}