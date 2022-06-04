using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using task_tracker.Data;
using task_tracker.DTOs;
using task_tracker.Models;

namespace task_tracker.Repositories
{
    public class TaskRepository
    {
        private DBcontext _context;
        public TaskRepository(DBcontext context)
        {
            _context = context;
        }
        public IEnumerable<GetTaskDTO> Get()
        {
            return _context.Tasks.Select(task => task.AsDTO())
                                .ToList();
        }
        public GetTaskDTO Get(int id)
        {
            return _context.Tasks.Where(t => t.task_id == id)
                                 .Select(task => task.AsDTO())
                                 .FirstOrDefault();
        }
        public void Create(SetTaskDTO task)
        {
            _context.Tasks.Add(task.AsModel());
            _context.SaveChanges();
        }
        public void Update(int id, SetTaskDTO task)
        {
            Task _task = _context.Tasks.FirstOrDefault(t => t.task_id == id);
            if (_task != null)
            {
                _task.name = task.name;
                _task.description = task.description;
                _task.priority = task.priority;
                _task.status = task.status;
                _task.ProjectId = task.ProjectId;
                _context.SaveChanges();
            }
        }
        public GetTaskDTO Delete(int id)
        {
            Task task = _context.Tasks.FirstOrDefault(t => t.task_id == id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                return task.AsDTO();
            }
            return null;
        }
        
        
        
    }
}
