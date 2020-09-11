namespace Services.AutoMapperConfig
{
    using global::AutoMapper;

    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            return config;
        }
    }
}