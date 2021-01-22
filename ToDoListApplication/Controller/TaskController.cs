using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToDoListApplication.Model;
using ToDoListApplication.View;
using ToDoListApplication.View.UserControls;

namespace ToDoListApplication.Controller
{
    public class TaskController : ITaskController
    {
        private IMainView mainView;
        private ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            mainView = new MainView(this);
            this.taskService = taskService;
        }
        public Form Start()
        {
            mainView.InitializeView();
            return (Form) mainView;
        }

        public void DeleteTask(int id)
        {
            taskService.DeleteTask(id);
            mainView.getTaskView().RemoveToDoItem(id);
        }

        public void DeleteTask2(int id)
        {
            var res = taskService.DeleteTask2(id);
            res.Effect(
                value => mainView.getTaskView().RemoveToDoItem(id),
                error => mainView.getTaskView().ShowErrorMessageBox(error));
        }


        public void ShowTasksForSpecificDate(DateTime searchDate)
        {
            List<Task> tasks = taskService.GetTasksByDate(searchDate);
            mainView.getTaskView().CreateToDoItems(tasks);
        }

        public void AddTask(Task task)
        {
            taskService.SaveTask(task);
            mainView.getTaskView().ClearTextBoxes();
            mainView.getTaskView().AddToDoItem(task);
        }

        public void EditTask(Task editedTask)
        {
            taskService.UpdateTask(editedTask);
            mainView.getTaskView().EditSpecificItem(editedTask);
        }
    }
}
