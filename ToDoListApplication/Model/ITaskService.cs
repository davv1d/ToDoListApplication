using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApplication.Model
{
    public interface ITaskService
    {
        Task SaveTask(Task task);

        Task DeleteTask(int taskId);

        List<Task> GetTasksByDate(DateTime date);

        Task UpdateTask(Task task);

        Result<Task> DeleteTask2(int taskId);
    }
}
