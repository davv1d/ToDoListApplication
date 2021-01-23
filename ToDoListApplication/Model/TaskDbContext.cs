using System.Data.Entity;

namespace ToDoListApplication.Model
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext() : base("name=ToDoListDbConnection")
        {

        }
        public virtual DbSet<Task> Tasks { get; set; }
    }
}
