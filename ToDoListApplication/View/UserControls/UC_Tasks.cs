using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ToDoListApplication.Controller;
using ToDoListApplication.Model;

namespace ToDoListApplication.View.UserControls
{
    public partial class UC_Tasks : UserControl, ITaskView
    {
        private DateTime selectedDate;
        private ITaskController taskController;
        public UC_Tasks(DateTime selectedDate, ITaskController taskController)
        {
            InitializeComponent();
            this.selectedDate = selectedDate;
            this.labelDate.Text = selectedDate.ToString("dddd, dd MMMM yyyy");
            this.taskController = taskController;
        }

        public void CreateToDoItems(List<Task> tasks)
        {
            flowLayoutPanelTasks.Controls.Clear();
            foreach (Task task in tasks)
            {
                var item = new ToDoItem(task, taskController);
                flowLayoutPanelTasks.Controls.Add(item);
            }
        }

        public void RemoveToDoItem(int id)
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

        public void AddToDoItem(Task task)
        {
            var item = new ToDoItem(task, taskController);
            flowLayoutPanelTasks.Controls.Add(item);
        }

        public void EditSpecificItem(Task task)
        {
            foreach (Control item in flowLayoutPanelTasks.Controls)
            {
                if (item.Name == task.TaskId.ToString())
                {
                    IToDoItem toDoItem = (IToDoItem)item;
                    toDoItem.EditItem(task);
                }
            }
        }

        public void ShowErrorMessageBox(string error)
        {
            MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
