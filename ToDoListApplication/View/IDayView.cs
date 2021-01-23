using System.Collections.Generic;
using ToDoListApplication.Model;

namespace ToDoListApplication.View
{
    public interface IDayView
    {
        void CreateTasksControlsView(List<Task> tasks);

        void RemoveTaskControl(int id);

        void ClearTextBoxes();

        void AddTaskControl(Task task);

        void EditSpecificTaskControl(Task task);

        void ShowErrorMessageBox(string error);
    }
}
