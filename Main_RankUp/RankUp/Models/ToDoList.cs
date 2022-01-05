using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankUp.Models
{
    public class ToDoList
    {
        public int id { get; set; }
        public User boardUser { get; set; }
        public string task { get; set; }
        public bool isDone { get; set; }
    }
}
