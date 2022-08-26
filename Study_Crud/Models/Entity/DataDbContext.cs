using Microsoft.EntityFrameworkCore;
using Study_Crud.Models.Entity;

namespace Study_Crud.Models.Entity
{
    public class DataDbContext:DbContext
    {

        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        { }
        public DbSet<Student> Students { get; set; }        
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Classes> Classess { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        
    }
}
