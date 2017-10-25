using BLL;
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

                DALFacade facade = new DALFacade(new DbOptions());

                using (var uow = facade.UnitOfWork)
                {
                    uow.CustomerRepository.Create(new Customer()
                    {
                        Id = 1,
                        Address = "Vej vej1",
                        FirstName = "test1",
                        LastName = "testesen1"
                    });
                    uow.CustomerRepository.Create(new Customer()
                    {
                        Id = 2,
                        Address = "Vej vej2",
                        FirstName = "test2",
                        LastName = "testesen2"
                    });
                    uow.Complete();
                }


            }

            app.UseMvc();
        }
    }
}

