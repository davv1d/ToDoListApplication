using System;
using System.Collections.Generic;

namespace ToDoListApplication.Model
{
    public interface ITaskService
    {
        Result<Task> SaveTask(Task task);

        Result<Task> DeleteTask(int taskId);

        List<Task> GetTasksByDate(DateTime date);

        Result<Task> UpdateTask(Task task);
    }
}
