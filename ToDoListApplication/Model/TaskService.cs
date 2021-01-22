using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApplication.Model
{
    public class TaskService : ITaskService
    {
        private TaskDbContext db;

        public TaskService()
        {
            this.db = new TaskDbContext();
        }

        public Task SaveTask(Task task)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
            return task;
        }

        public Task DeleteTask(int taskId)
        {
            Task task = db.Tasks.SingleOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
            return task;
        }

        public Result<Task> DeleteTask2(int taskId)
        {
            Task task = db.Tasks.SingleOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
                return Result<Task>.success(task);
            }
            return Result<Task>.failure("Task does not exist");
        }
        public List<Task> GetTasksByDate(DateTime date)
        {
            var r = date.ToString("dd MMMM yyyy");
            
            return db.Tasks
                .Where(t => t.ScheduledDate.Day == date.Day && t.ScheduledDate.Month == date.Month && t.ScheduledDate.Year == date.Year)
                .ToList();
        }

        public Task UpdateTask(Task task)
        {
            Task taskFound = db.Tasks.SingleOrDefault(t => t.TaskId == task.TaskId);
            if (taskFound != null)
            {
                taskFound.Title = task.Title;
                taskFound.Description = task.Description;
                db.SaveChanges();
            }
            return task;
        }
    }
}
