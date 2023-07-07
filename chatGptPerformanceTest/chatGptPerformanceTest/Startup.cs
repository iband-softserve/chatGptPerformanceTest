using chatGptPerformanceTest.Repositories.Implementation;
using chatGptPerformanceTest.Services.Implementation;
using chatGptPerformanceTest.Shared.Abstract.Repositories;
using chatGptPerformanceTest.Shared.Abstract.Services;
using chatGptPerformanceTest.Shared.ConfigurationModels;
using Microsoft.OpenApi.Models;

namespace chatGptPerformanceTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            this.Configuration = configuration;
            this.Env = env;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Env { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            this.SetupDependencyInjection(services);

            services
                .AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "chatGptPerformanceTest", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "chatGptPerformanceTest v1"));
            }

            if (!env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SetupDependencyInjection(IServiceCollection services)
        {
            var countriesApiConfiguration = this.Configuration.GetSection("CountriesApiConfiguration").Get<CountriesApiConfiguration>();
            services.AddSingleton(countriesApiConfiguration);

            services.AddHttpClient();
            services.AddScoped<ICountriesRepository, CountriesRepository>();
            services.AddScoped<ICountriesService, CountriesService>();
        }
    }
}
