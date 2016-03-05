﻿using System.Collections.Generic;

namespace ORM
{
    public class User : IOrmKeyEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public virtual ICollection<TaskUser> Tasks { get; set; }
        public User()
        {
            Tasks = new HashSet<TaskUser>();
        }
    }
}
