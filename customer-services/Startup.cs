using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using customer_services.Application.Interfaces;
using customer_services.Application.UseCases.Customer.Command.CreateCustomer;
using customer_services.Application.UseCases.Customer.Queries.GetCustomer;
using customer_services.Application.UseCases.Payment.Command.CreatePayment;
using customer_services.Infrastructure.Presistences;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace customer_services
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
            services.AddDbContext<CustomerContext>(op => op.UseNpgsql("Host=127.0.0.1;Username=postgres;Password=docker;Database=customer_db"));

            services.AddMediatR(typeof(GetCustomerQueryHandler).GetTypeInfo().Assembly);

            services.AddMvc()
                    .AddFluentValidation();

            services.AddTransient<IValidator<CreateCustomerCommand> , CreateCustomerCommandValidator>();
            services.AddTransient<IValidator<CreatePaymentCommand> , CreatePaymentCommandValidator>();

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
