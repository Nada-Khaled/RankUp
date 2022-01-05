using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class TaskRepository:ITaskRepository
    {
        private readonly AppDBContext appDBContext;

        public TaskRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public bool AddNewTask(ToDoList newTask)
        {
            try
            {
                appDBContext.toDoList.Add(newTask);
                appDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ToDoList> GetTasks(string userId)
        {
            return appDBContext.toDoList.Where(c => c.boardUser.Id == userId).ToList();
        }

        public ToDoList GetTaskById(int taskId)
        {
            return appDBContext.toDoList.Where(c => c.id == taskId).Include(c=> c.boardUser).First();
        }
        public bool DeleteTask(int taskId)
        {
            try {
                appDBContext.toDoList.Remove(appDBContext.toDoList.Find(taskId));
                appDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false; 
            }
        }

        public bool UpdateTaskStatus(int taskId, bool taskStatus)
        {
            try { 
            ToDoList task = GetTaskById(taskId);

            task.isDone = taskStatus;
            appDBContext.SaveChanges();
            return true;

        }
            catch
            {
                return false;
            }
        }
    }
}
