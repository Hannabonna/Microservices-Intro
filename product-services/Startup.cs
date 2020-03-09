using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using product_services.Application.Interfaces;
using product_services.Application.UseCases.Product.Command.CreateProduct;
using product_services.Application.UseCases.Product.Queries.GetProduct;
using product_services.Infrastructure.Presistences;

namespace product_services
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
            services.AddDbContext<ProductContext>(op => op.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=docker;Database=product_db"));

            services.AddMediatR(typeof(GetProductQueryHandler).GetTypeInfo().Assembly);

            services.AddMvc()
                    .AddFluentValidation();

            services.AddTransient<IValidator<CreateProductCommand> , CreateProductCommandValidator>();
  
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
