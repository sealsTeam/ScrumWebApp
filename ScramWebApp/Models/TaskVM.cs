using System.Collections.Generic;

namespace ScramWebApp.Models
{
    public class TaskVM
    {
        public List<Backlog> Backlogs { get; set; }
        public List<TaskModel> Tasks { get; set; }
    }
}
