using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using task_tracker.DTOs;

namespace task_tracker.Models
{
    public class Task
    {   
        [Key]
        public int task_id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        public int priority { get; set; }
        public task_status status { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum task_status
        {
            ToDo,
            InProgress,
            Done
        }
    }
}
