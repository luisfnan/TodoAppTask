﻿using System;


namespace TodoAppTask.Models
{
    public class Task
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}