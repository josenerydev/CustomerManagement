using CustomerManagement.Logic.Model;
using CustomerManagement.Logic.SeedWork;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Reflection;

namespace CustomerManagement.Api.Utils
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(Assembly.GetAssembly(typeof(AggregateRoot)));

            services.AddSingleton(ctx => new EventListener(ctx.GetRequiredService<IMediator>()));
            services.AddSingleton(ctx => new SessionFactory(Configuration["ConnectionString"], ctx.GetRequiredService<EventListener>()));
            services.AddScoped<UnitOfWork>();
            services.AddTransient<CustomerRepository>();
            services.AddTransient<IndustryRepository>();
            services.AddTransient<IEmailGateway, EmailGateway>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
