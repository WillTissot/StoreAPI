using AutoMapper;
using Newtonsoft.Json;
using StoreAPI.Data;
using StoreAPI.Dtos;
using StoreAPI.Models.User;
using System.Collections.Generic;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace StoreAPI
{
    public class Startup
    {
        private readonly string _path = @"C:\Users\vasil\Downloads\sample_user.json";

        private readonly IMapper _mapper;

        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }

        public void ConfigureServices(IServiceCollection services, IServiceProvider serviceProvider)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddRazorPages();
            var context = services.BuildServiceProvider().GetService<ApplicationDbContext>();
            LoadUsers(serviceProvider, context, mapper).Wait();
        }

        private async Task LoadUsers(IServiceProvider serviceProvider, ApplicationDbContext db, IMapper mapper)
        {
            using (StreamReader r = new StreamReader(Path.GetFullPath(this._path)))
            {
                string json = r.ReadToEnd();

                var users = JsonConvert.DeserializeObject<UsersSerializeDto>(json);

                foreach(var user in users.Users)
                {
                    var customer = mapper.Map<Customer>(user);

                    var item = 1;
                }

            }

        }
    }
}
