using System.Windows.Forms;
using ToDoListApplication.View;

namespace ToDoListApplication
{
    public interface IMainView
    {
        Form InitializeView();

        IDayView getDayView();
    }
}
