﻿using System.Collections.Generic;

namespace ORM
{
    public class Folder: IOrmKeyEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}