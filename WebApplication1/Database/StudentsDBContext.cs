using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WebApplication1.Models;
using WebApplication1.Database.Configurations;


namespace WebApplication1.Database
{
    public class StudentDbContext : DbContext
    {
            //Добавляем таблицы
            DbSet<Student> Students { get; set; }

            DbSet<Group> Groups { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Добавляен конфигурации к таблица
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
      
    }

   
}



