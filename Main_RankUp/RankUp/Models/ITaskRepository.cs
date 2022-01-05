using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public interface ITaskRepository
    {
        public bool AddNewTask(ToDoList newTask);
        public List<ToDoList> GetTasks(string userId);
        public ToDoList GetTaskById(int taskId);
        public bool UpdateTaskStatus(int taskId, bool taskStatus);
        public bool DeleteTask(int taskId);
    }
}
