using Microsoft.EntityFrameworkCore;
using RestFullAppTemplate.Data;
using RestFullAppTemplate.Data.Context;
using RestFullAppTemplate.Data.Repositories;

namespace RestFullAppTemplate.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDependencyInjection(services);

            services.RegisterMapsterConfiguration();

            services.AddDbContext<ApplicationDbContext>((option) =>
            {
                option.UseNpgsql(_configuration.GetConnectionString("DefaultSQLConnection"));
            });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseHttpsRedirection();
        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
            var repo = Data.ContainerRegistration.GetInterfaceBindings();
            foreach (var type in repo)
            {
                services.AddSingleton(type.Key, type.Value);
            }

            var srv = Services.ContainerRegistration.GetInterfaceBindings();
            foreach (var type in srv)
            {
                services.AddSingleton(type.Key, type.Value);
            }
        }
    }
}