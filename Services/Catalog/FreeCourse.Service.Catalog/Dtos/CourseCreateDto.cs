﻿namespace FreeCourse.Service.Catalog.Dtos
{
    public class CourseCreateDto
    {
        public string Name { get; set; }
        public string Picture { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public FeatureDto Feature { get; set; }
        public string Category_Id { get; set; }
    }
}
