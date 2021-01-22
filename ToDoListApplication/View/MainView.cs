using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoListApplication.Controller;
using ToDoListApplication.Model;
using ToDoListApplication.View;
using ToDoListApplication.View.UserControls;
using Task = ToDoListApplication.Model.Task;

namespace ToDoListApplication
{
    public partial class MainView : Form, IMainView
    {
        private DateTime selectedDate;
        private ITaskController taskController;
        private UC_Tasks ucTasks;
        private bool move;
        private int moveX;
        private int moveY;
        public MainView(ITaskController taskController)
        {
            this.taskController = taskController;
        }
        public Form InitializeView()
        {
            InitializeComponent();
            AddControlsToPanel(new UC_Home());
            return this;
        }
        public ITaskView getTaskView()
        {
            return this.ucTasks;
        }
        private void btnShowDay_Click(object sender, EventArgs e)
        {
            selectedDate = dateTimePicker1.Value;
            ucTasks = new UC_Tasks(selectedDate, taskController);
            taskController.ShowTasksForSpecificDate(selectedDate);
            AddControlsToPanel(ucTasks);
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelContent.Controls.Clear();
            panelContent.Controls.Add(c);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            moveX = e.X;
            moveY = e.Y;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if(move)
            {
                this.SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY);
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }
    }
}
