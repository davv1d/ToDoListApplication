using System.Data.Entity;

namespace ToDoListApplication.Model
{
    class TaskDbContext : DbContext
    {
        public TaskDbContext() : base("name=ToDoListDbConnection")
        {

        }
        public DbSet<Task> Tasks { get; set; }
    }
}
