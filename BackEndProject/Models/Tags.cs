﻿namespace BackEndProject.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  List<CourseTags> CourseTags { get; set; }
    }
}
