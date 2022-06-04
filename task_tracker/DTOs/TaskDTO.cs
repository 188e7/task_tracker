using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using task_tracker.Models;

namespace task_tracker.DTOs
{
    public class GetTaskDTO
    {
        public int task_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int priority { get; set; }
        public string status { get; set; }
    }
    public class SetTaskDTO
    {
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public int priority { get; set; }
        [Range(0, 2, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public  Task.task_status status { get; set; }
        public int ProjectId { get; set; }
    }

}
