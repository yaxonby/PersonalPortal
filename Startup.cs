using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DBRepository.Interfaces;
using DBRepository.Repositories;


namespace PersonalPortal
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			services.AddScoped<IRepositoryContextFactory, RepositoryContextFactory>(); // 1
			services.AddScoped<IBlogRepository>(provider =>
				new BlogRepository(Configuration.GetConnectionString("DefaultConnection"),
					provider.GetService<IRepositoryContextFactory>())); // 2
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			app.UseMvc();

		}
	}
}