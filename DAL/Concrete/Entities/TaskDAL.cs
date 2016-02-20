﻿using System;
using DAL.Interfaces.Entities;

namespace DAL.Concrete.Entities
{
    public class TaskDAL: IDALKeyEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueTime { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}
