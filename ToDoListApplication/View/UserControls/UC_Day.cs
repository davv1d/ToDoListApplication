using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ToDoListApplication.Controller;
using ToDoListApplication.Model;

namespace ToDoListApplication.View.UserControls
{
    public partial class UC_Day : UserControl, IDayView
    {
        private readonly DateTime selectedDate;
        private readonly ITaskController taskController;
        public UC_Day(DateTime selectedDate, ITaskController taskController)
        {
            InitializeComponent();
            this.selectedDate = selectedDate;
            this.labelDate.Text = selectedDate.ToString("dddd, dd MMMM yyyy");
            this.taskController = taskController;
        }

        public void CreateTasksControlsView(List<Task> tasks)
        {
            flowLayoutPanelTasks.Controls.Clear();
            foreach (Task task in tasks)
            {
                var item = new UC_Task(task, taskController);
                flowLayoutPanelTasks.Controls.Add(item);
            }
        }

        public void RemoveTaskControl(int id)
        {
            foreach (Control item in flowLayoutPanelTasks.Controls)
            {
                if (item.Name == id.ToString())
                {
                    flowLayoutPanelTasks.Controls.Remove(item);
                }
            }
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = textBoxTitle.Text.Trim();
            if (title.Length > 0)
            {
                var desc = textBoxDesc.Text.Trim();
                Task task = new Task() { Title = title, Description = desc, ScheduledDate = selectedDate };
                taskController.AddTask(task);
            }
        }

        public void ClearTextBoxes()
        {
            textBoxTitle.Clear();
            textBoxDesc.Clear();
        }

        public void AddTaskControl(Task task)
        {
            var item = new UC_Task(task, taskController);
            flowLayoutPanelTasks.Controls.Add(item);
        }

        public void EditSpecificTaskControl(Task task)
        {
            foreach (Control item in flowLayoutPanelTasks.Controls)
            {
                if (item.Name == task.TaskId.ToString())
                {
                    ITaskView toDoItem = (ITaskView)item;
                    toDoItem.EditTaskLabels(task);
                }
            }
        }

        public void ShowErrorMessageBox(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
