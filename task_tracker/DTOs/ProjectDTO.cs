using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using task_tracker.Models;

namespace task_tracker.DTOs
{
    public class GetProjectDTO
    {
        public int project_id { get; set; }
        public string name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? start_date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? completion_date { get; set; }
        public int priority { get; set; }
        public string status { get; set; }
        public virtual IList<GetTaskDTO> Tasks { get; set; }
    }
    public class SetProjectDTO
    {
        [Required]
        public string name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? start_date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}}", ApplyFormatInEditMode = true)]
        public DateTime? completion_date { get; set; }
        
        public int priority { get; set; }
        [Range(0, 2, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public Project.project_status status { get; set; }
    }
}
