using Microsoft.EntityFrameworkCore;
using ToDoApi.Entities;
 
namespace ToDoApi.Helpers
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options)
        {
        }

        public DbSet<ToDoTask> ToDoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>(task =>
            {
                var taskId = task.Property(p => p.Id);
                taskId.ValueGeneratedOnAdd();
            });
        }
    }
}