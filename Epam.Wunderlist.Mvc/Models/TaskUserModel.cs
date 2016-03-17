using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskUserModel
    {
        [Display(Name = "User")]
        public string UserLogin { get; set; }

        [Required]        
        public int UserId { get; set; }

        [Display(Name = "Task")]
        public string TaskTitle { get; set; }

        [Required]
        public int TaskId { get; set; }

        [Required]
        [Display(Name = "Progress")]        
        public int Progress { get; set; }
    }
}
