using System;
using BLL;
using BLL.BusinessObjects;
using BLL.Facade;
using DAL;
using DAL.Entities;
using DAL.Facade;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CustomerRestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

			services.AddCors(o => o.AddPolicy("MyPolicy", builder => {
				builder.WithOrigins("http://localhost:4200")
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));

            services.AddSingleton(Configuration);
            services.AddScoped<IBLLFacade, BLLFacade>();
        
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            if (env.IsDevelopment())
            {
				loggerFactory.AddConsole(Configuration.GetSection("Logging"));
				loggerFactory.AddDebug();

				app.UseDeveloperExceptionPage();
            }

            IBLLFacade facade = new BLLFacade(Configuration);

            facade.OrderService.Create(new OrderBO()
            {
                Id = 3,
                DeliveryDate = DateTime.Now,
                OrderDate = DateTime.Now
            });

            facade.ProductService.Create(new ProductBO()
            {
                Id = 3,
                Name = "Telefon",
                ListPrice = 120
            });

            facade.OrderItemService.Create(new OrderItemBO()
            {
                Id = 3,
                Quantity = 10,
                UnitPrice = 100
            });

            facade.CustomerService.Create(new CustomerBO()
            {
                Id = 1,
                FirstName = "Hans",
                LastName = "Hansen",
                Address = "Hansvej 1"
            });

            facade.CustomerService.Create(new CustomerBO()
            {
                Id = 2,
                FirstName = "Kurt",
                LastName = "Kurtsen",
                Address = "Kurtvej 2"
            });

            app.UseMvc();
        }
    }
}

