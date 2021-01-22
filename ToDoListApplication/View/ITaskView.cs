using System.Collections.Generic;
using ToDoListApplication.Model;

namespace ToDoListApplication.View
{
    public interface ITaskView
    {
        void CreateToDoItems(List<Task> tasks);

        void RemoveToDoItem(int id);

        void ClearTextBoxes();

        void AddToDoItem(Task task);

        void EditSpecificItem(Task task);

        void ShowErrorMessageBox(string error);
    }
}
