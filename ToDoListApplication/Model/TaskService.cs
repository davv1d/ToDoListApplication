using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoListApplication.Model
{
    public class TaskService : ITaskService
    {
        private readonly TaskDbContext db;

        public TaskService(TaskDbContext taskDbContext)
        {
            this.db = taskDbContext;
        }

        public Result<Task> SaveTask(Task task)
        {
            db.Tasks.Add(task);
            try
            {
                db.SaveChanges();
                return Result<Task>.success(task);
            }
            catch (Exception e)
            {
                return Result<Task>.failure(e.Message);
            }
        }

        public Result<Task> DeleteTask(int taskId)
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

        public Result<Task> UpdateTask(Task task)
        {
            Task taskFound = db.Tasks.SingleOrDefault(t => t.TaskId == task.TaskId);
            if (taskFound != null)
            {
                taskFound.Title = task.Title;
                taskFound.Description = task.Description;
                db.SaveChanges();
                return Result<Task>.success(task);
            }
            return Result<Task>.failure("Task does not exist");
        }
    }
}
