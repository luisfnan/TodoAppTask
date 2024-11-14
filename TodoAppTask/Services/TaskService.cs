using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoAppTask.Models;

namespace TodoAppTask.Services
{
    public class TaskService
    {
        private readonly List<Task> _tasks = new List<Task>();
        private int _nextId = 1;

        public IEnumerable<Task> GetAll() => _tasks;

        public Task GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        public Task Add(Task task) 
        { 
          task.Id = _nextId++;
          task.CreatedAt = DateTime.Now;
            _tasks.Add(task);
            return task;


        }
    }
}