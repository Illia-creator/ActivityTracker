﻿using System.ComponentModel.DataAnnotations;

namespace ActivityTracker.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
