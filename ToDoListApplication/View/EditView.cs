using System;
using System.Windows.Forms;
using ToDoListApplication.Controller;
using ToDoListApplication.Model;

namespace ToDoListApplication
{
    public partial class EditView : Form
    {
        private readonly Task task;
        private readonly ITaskController taskController;
        public EditView(ITaskController taskController, Task task)
        {
            InitializeComponent();
            this.taskController = taskController;
            this.task = task;
            this.textBoxTitle.Text = task.Title;
            this.textBoxDesc.Text = task.Description;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Task editedTask = new Task()
            {
                TaskId = task.TaskId,
                Title = textBoxTitle.Text,
                Description = textBoxDesc.Text,
                ScheduledDate = task.ScheduledDate
            };

            taskController.EditTask(editedTask);
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
