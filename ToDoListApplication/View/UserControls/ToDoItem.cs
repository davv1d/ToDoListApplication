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
using ToDoListApplication.View;

namespace ToDoListApplication
{
    public partial class ToDoItem : UserControl, IToDoItem
    {
        private ITaskController taskController;
        private Task task;
        public ToDoItem()
        {
            InitializeComponent();
        }

        public ToDoItem(Task task, ITaskController taskController)
        {
            InitializeComponent();
            this.task = task;
            this.Name = task.TaskId.ToString();
            this.labelTitle.Text = task.Title;
            this.labelDesc.Text = task.Description;
            this.taskController = taskController;

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete this task?";
            string caption = "Delete Task";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.Yes)
            {
                //   taskController.DeleteTask(task.TaskId);
                taskController.DeleteTask2(0);
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditView form = new EditView(taskController, task);
            form.ShowDialog();
        }

        public void EditItem(Task task)
        {
            this.labelTitle.Text = task.Title;
            this.labelDesc.Text = task.Description;
        }
    }
}
