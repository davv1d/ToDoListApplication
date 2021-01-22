using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToDoListApplication.Model;

namespace ToDoListApplication.Controller
{
    public interface ITaskController
    {
        Form Start();

        void DeleteTask(int id);
        void ShowTasksForSpecificDate(DateTime searchDate);

        void AddTask(Task task);

        void EditTask(Task editedTask);

        void DeleteTask2(int id);
    }
}
