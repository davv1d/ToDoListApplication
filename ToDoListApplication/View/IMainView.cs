using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToDoListApplication.Controller;
using ToDoListApplication.Model;
using ToDoListApplication.View;

namespace ToDoListApplication
{
    public interface IMainView
    {
        Form InitializeView();

        ITaskView getTaskView();
    }
}
