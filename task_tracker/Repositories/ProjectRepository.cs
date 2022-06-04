using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task_tracker.Data;
using task_tracker.DTOs;
using task_tracker.Models;

namespace task_tracker.Repositories
{
    public class ProjectRepository
    {
        private DBcontext _context;
        public ProjectRepository(DBcontext context)
        {
            _context = context;
        }
        public IEnumerable<GetProjectDTO> Get()
        {
            return _context.Projects.Include(project => project.Tasks)
                                    .Select(project => project.AsDTO())
                                    .ToList();
        }
        public GetProjectDTO Get(int id)
        {
            return _context.Projects.Where(project => project.project_id == id)
                                    .Select(project => project.AsDTO())
                                    .FirstOrDefault();
        }
        public void Create(SetProjectDTO project)
        {
            _context.Projects.Add(project.AsModel());
            _context.SaveChanges();
        }
        public void Update(int id, SetProjectDTO project)
        {
            Project _project = _context.Projects.FirstOrDefault(p => p.project_id == id);
            if (_project != null)
            {
                _project.name = project.name;
                _project.start_date = project.start_date;
                _project.completion_date = project.completion_date;
                _project.priority = project.priority;
                _project.status = project.status;
                _context.SaveChanges();
            }
        }
        public GetProjectDTO Delete(int id)
        {
            Project project = _context.Projects.FirstOrDefault(p => p.project_id == id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
                return project.AsDTO();
            }
            return null;
            
        }
    }
}
