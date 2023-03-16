﻿using FreeCourse.Service.Catalog.Model;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Service.Catalog.Dtos
{
    public class CourseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Category_Id { get; set; }
        public FeatureDto Feature { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
    }
}
