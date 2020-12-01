using DfwRest.Domain;
using DfwRest.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DfwRest
{
    public class Startup
    {
        private const string AllowAllPolicy = "AllowAllPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IWordService, WordService>();
            services.AddScoped<IWordRepo, WordRepo>();
            services.AddDbContext<WordContext>(o => o.UseInMemoryDatabase("InMemoryDb"));

            services.AddControllers();

            services.AddCors(o => o.AddPolicy(AllowAllPolicy, options =>
            {
                options.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-InlineCount");
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            // This would need to be locked down as needed (very open right now)
            app.UseCors(AllowAllPolicy);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}