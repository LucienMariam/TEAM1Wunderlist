using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int FolderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueTime { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class UserTask
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Progress")]
        public int Progress { get; set; }

    }
}
