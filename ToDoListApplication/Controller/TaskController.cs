using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ToDoListApplication.Model;

namespace ToDoListApplication.Controller
{
    public class TaskController : ITaskController
    {
        private readonly IMainView mainView;
        private readonly ITaskService taskService;

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
                    value => mainView.getDayView().RemoveTaskControl(id),
                    error => mainView.getDayView().ShowErrorMessageBox(error));
        }

        public void ShowTasksForSpecificDate(DateTime searchDate)
        {
            List<Task> tasks = taskService.GetTasksByDate(searchDate);
            mainView.getDayView().CreateTasksControlsView(tasks);
        }

        public void AddTask(Task task)
        {
            taskService.SaveTask(task)
                .Effect(
                    t =>
                    {
                        mainView.getDayView().ClearTextBoxes();
                        mainView.getDayView().AddTaskControl(t);
                    },
                    error => mainView.getDayView().ShowErrorMessageBox(error)
                );
        }

        public void EditTask(Task editedTask)
        {
            taskService.UpdateTask(editedTask)
                .Effect(
                    t => mainView.getDayView().EditSpecificTaskControl(editedTask),
                    error => mainView.getDayView().ShowErrorMessageBox(error)
                );
        }
    }
}
