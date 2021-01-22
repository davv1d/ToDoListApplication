using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoListApplication.Model;

namespace ToDoListApplication.View
{
    public interface IToDoItem
    {
        void EditItem(Task task);
    }
}
