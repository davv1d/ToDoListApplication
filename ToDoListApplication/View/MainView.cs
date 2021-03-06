﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoListApplication.Controller;
using ToDoListApplication.View;
using ToDoListApplication.View.UserControls;

namespace ToDoListApplication
{
    public partial class MainView : Form, IMainView
    {
        private DateTime selectedDate;
        private ITaskController taskController;
        private UC_Day ucTasks;
        private bool move;
        private int moveX;
        private int moveY;
        public MainView(ITaskController taskController)
        {
            InitializeComponent();
            this.taskController = taskController;
        }
        public Form InitializeView()
        {
            AddControlsToPanel(new UC_Home());
            return this;
        }
        public IDayView getDayView()
        {
            return this.ucTasks;
        }
        private void btnShowDay_Click(object sender, EventArgs e)
        {
            selectedDate = dateTimePicker1.Value;
            ucTasks = new UC_Day(selectedDate, taskController);
            taskController.ShowTasksForSpecificDate(selectedDate);
            AddControlsToPanel(ucTasks);
            var task = new Task(() => { this.btnShowDay.Text = "teert"; });
           // task.RunSynchronously();
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
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - moveX, MousePosition.Y - moveY);
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void btnMinimalize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
