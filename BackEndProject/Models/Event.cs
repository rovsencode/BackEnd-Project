﻿using Microsoft.VisualBasic;

namespace BackEndProject.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string? Venue { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Speaker> Speakers { get; set; }
    }
}
