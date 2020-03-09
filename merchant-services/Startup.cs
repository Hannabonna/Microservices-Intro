using System;
using System.Reflection;
using System.Threading.Tasks;
using merchant_services.Application.Interfaces;
using merchant_services.Application.UseCases.Merchant.Command.CreateMerchant;
using merchant_services.Application.UseCases.Merchant.Queries.GetMerchant;
using merchant_services.Infrastructure.Presistences;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace merchant_services
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
            services.AddDbContext<MerchantContext>(op => op.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=docker;Database=merchant_db"));

            services.AddMediatR(typeof(GetMerchantQueryHandler).GetTypeInfo().Assembly);

            services.AddMvc()
                    .AddFluentValidation();

            services.AddTransient<IValidator<CreateMerchantCommand> , CreateMerchantCommandValidator>();
  
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidator<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
