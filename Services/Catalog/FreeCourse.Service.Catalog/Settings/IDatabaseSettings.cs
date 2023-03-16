namespace FreeCourse.Service.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public String CourceCollectionName { get; set; }
        public String CategoryCollectionName { get; set; }
        public String ConnectionString { get; set; }
        public String DatabaseName { get; set; }

    }
}
