using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToDoListApplication.Controller;
using ToDoListApplication.Model;

namespace ToDoListApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ITaskService taskService = new TaskService();
            ITaskController taskController = new TaskController(taskService);
            Application.Run(taskController.Start());
        }
    }
}
