using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
