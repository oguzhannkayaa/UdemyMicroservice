﻿namespace FreeCourse.Service.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CourceCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
