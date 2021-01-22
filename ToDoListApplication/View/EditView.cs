using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToDoListApplication.Controller;
using ToDoListApplication.Model;

namespace ToDoListApplication
{
    public partial class EditView : Form
    {
        private Task task;
        private ITaskController taskController;
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
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
