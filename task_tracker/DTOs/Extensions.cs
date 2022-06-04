using System;
using System.Collections.Generic;
using System.Linq;
using task_tracker.DTOs;
using task_tracker.Models;

namespace task_tracker
{
    public static class Extensions
    {
        // Additional static extension class for converting DTOs and Models
        public static GetProjectDTO AsDTO(this Project project)
        {
            if(project.Tasks != null)
            return new GetProjectDTO()
            {
                project_id = project.project_id,
                name = project.name,
                start_date = project.start_date,
                completion_date = project.completion_date,
                priority = project.priority,
                status = project.status.ToString(),
                Tasks = project.Tasks.Select(task=>task.AsDTO()).ToList()
            };
            return new GetProjectDTO()
            {
                project_id = project.project_id,
                name = project.name,
                start_date = project.start_date,
                completion_date = project.completion_date,
                priority = project.priority,
                status = project.status.ToString()
            };
        }
        public static GetTaskDTO AsDTO(this Task task)
        {
            if(task!=null)
            return new GetTaskDTO()
            {
                task_id = task.task_id,
                name = task.name,
                description = task.description,
                priority = task.priority,
                status = task.status.ToString(),
            };
            return new GetTaskDTO();
        }
        public static Project AsModel(this SetProjectDTO project)
        {
            return new Project()
            {
                name = project.name,
                start_date = project.start_date,
                completion_date = project.completion_date,
                priority = project.priority,
                status = project.status
            };
        }
        public static Task AsModel(this SetTaskDTO task)
        {
            return new Task()
            {
                name = task.name,
                description = task.description,
                priority = task.priority,
                status = task.status,
                ProjectId = task.ProjectId
            };
        }
    }
}
