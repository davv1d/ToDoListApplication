using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ToDoListApplication.Model;

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
            return (Form)mainView;
        }

        public void DeleteTask(int id)
        {
            taskService.DeleteTask(id)
                .Effect(
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
            taskService.SaveTask(task)
                .Effect(
                    t =>
                    {
                        mainView.getTaskView().ClearTextBoxes();
                        mainView.getTaskView().AddToDoItem(t);
                    },
                    error => mainView.getTaskView().ShowErrorMessageBox(error)
                );
        }

        public void EditTask(Task editedTask)
        {
            taskService.UpdateTask(editedTask)
                .Effect(
                    t => mainView.getTaskView().EditSpecificItem(editedTask),
                    error => mainView.getTaskView().ShowErrorMessageBox(error)
                );
        }
    }
}
