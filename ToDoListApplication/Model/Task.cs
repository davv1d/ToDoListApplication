using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApplication.Model
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
