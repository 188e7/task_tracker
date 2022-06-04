using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task_tracker.Models
{
    public class Project
    {
        [Key]
        public int project_id { get; set; }
        [Required]
        public string name { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? start_date { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? completion_date { get; set; }


        public int priority { get; set; }
        public project_status status { get; set; }
        public virtual IList<Task> Tasks { get; set; }
        public enum project_status
        {
            NotStarted,
            Active,
            Completed
        }
    }
}
